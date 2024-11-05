using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Specialized;

namespace Middle;

public class BackFunctions
{
    /// <summary>
    /// Testing Dictionary for function will be moved config files after the the user can update it in the UI
    /// </summary>
    public Dictionary<string, string> ProgramMap = new();//Testing for now
	private Stack<Action> UndoCode = new();
	private Stack<Action> UIUndoCode = new();

    private Stack<int> UILinks = new();

    public void AddUIUndoAction(Action a)
    {
        if (UndoCode.Count == 0) return;
        UILinks.Push(UndoCode.Count-1);
        UIUndoCode.Push(a);
    }

	public BackFunctions()
    {
        if (OperatingSystem.IsWindows())
        {
            ProgramMap.Add(".txt", "notepad.exe");
        }
        else
        {
            ProgramMap.Add(".txt", "gnome-text-editor");
        }
    }

    public void Undo()
    {
        if (UndoCode.Count > 0)
        {
            Action a = UndoCode.Pop();
            a.Invoke();
        }
		if (UILinks.Count > 0 && UILinks.Peek() == UndoCode.Count)
		{
            _ = UILinks.Pop();
			Action a = UIUndoCode.Pop();
			a.Invoke();
		}
	}

    public bool TryGetSaveFilePath(string name, out string path)
    {
        path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        path = Path.Join(path, "FileBoss");
		if (!Directory.Exists(path)) Directory.CreateDirectory(path);
		path = Path.Join(path, name);
        return File.Exists(path);
	}

    public string[] GetFavorites()
    {
        if (!TryGetSaveFilePath("favorits.txt", out string f)) RealCreateFile(f);
        string[] tmp = File.ReadAllLines(f);
        List<string> good = new();
        foreach (string item in tmp)
        {
            if (File.Exists(item))
				good.Add(item);
        }
		File.WriteAllLines(f, good);
		return good.ToArray();
    }

	public void AddFavorites(string name)
	{
		if (!TryGetSaveFilePath("favorits.txt", out string f)) RealCreateFile(f);
		List<string> old = File.ReadAllLines(f).ToList();
        old.Add(Path.Join(BasePath, name));
        File.WriteAllLines(f, old);
	}

	public string? GetProgram(string FileName)
    {
        FileInfo FI = new FileInfo(FileName);
        if (ProgramMap.TryGetValue(FI.Extension.ToLower(), out string? Program)) return Program;
        return null;
    }

    private string bp = "";

    public required string BasePath
    {
        get => bp;
        set
        {
            if (!Path.Exists(value)) throw new UIException("The provided directory is not valid");
            UndoCode.Push(() => { BasePath = bp; });
            bp = value;
        }
    }

    public void Open(string FileToOpen)
    {
        try
        {
            if (!File.Exists(FileToOpen)) throw new UIException("The provided file is not valid");
            FileInfo FI = new FileInfo(FileToOpen);

            if (ProgramMap.TryGetValue(FI.Extension.ToLower(), out string? Program))
            {
                OpenWith(Program, FileToOpen);
                return;
            }
            Process.Start(FileToOpen);
        }
        catch (Win32Exception e)
        {
            throw new UIException($"There was a problem starting the file '{FileToOpen}'.\n Details: {e.Message}");
        }
        catch (InvalidOperationException e)
        {
            throw new UIException($"Invalid operation while trying to open '{FileToOpen}'.\n Details: {e.Message}");
        }
        catch (Exception e)
        {
            throw new UIException($"An unexpected error occurred while trying to open '{FileToOpen}'.\n Details: {e.Message}", ErrorType.Unknown);
        }
    }

    public void PastFiles(StringCollection paths)
    {
		foreach (var f in paths)
		{
            if (string.IsNullOrWhiteSpace(f) || !File.Exists(f)) continue;
            FileInfo old = new(f);
            string name = old.Name;
			if (File.Exists(Path.Join(BasePath, name)))
			{
                string ext = old.Extension;
                name = name.Remove(name.Length - ext.Length, ext.Length);
				void withnum(int i)
				{
					if (File.Exists(Path.Join(BasePath, name + $" ({i}){ext}")))
					{
                        withnum(i+1);
					}
                    else
                    {
                        name += $" ({i}){ext}";
					}
				}
                withnum(1);
			}
			File.Copy(f, Path.Join(BasePath, name));
		}
	}
    
    public void OpenWith(string Program, string FileToOpen)
    {
        try
        {
            if (!File.Exists(FileToOpen)) throw new UIException("The provided file is not valid");
            Process p = new Process()
            {
                StartInfo =
                {
                    FileName = Program,
                    Arguments = Path.Join(BasePath, FileToOpen)
                }
            };
            _ = p.Start();
        }
        catch (FileNotFoundException e)
        {
            throw new UIException($"Program '{Program}' not found. Details: {e.Message}");
        }
        catch (Win32Exception e)
        {
            throw new UIException($"There was a problem starting the program '{Program}'. Details: {e.Message}");
        }
        catch (InvalidOperationException e)
        {
            throw new UIException($"The process start info is invalid. Details: {e.Message}");
        }
        catch (Exception e)
        {
            throw new UIException($"An unexpected error occurred while trying to open '{FileToOpen}'.\n Details: {e.Message}", ErrorType.Unknown);
        }
    }

	public void CreateFile(string FileName)
    {
        RealCreateFile(Path.Join(BasePath, FileName));
		UndoCode.Push(() => { DeleteFile(FileName); });
	}


	public static void RealCreateFile(string FileName)
    {
        try
        {
            if (File.Exists(FileName))
            {
                throw new UIException($"File '{FileName}' already exists");
            }
            else
            {
                using (_ = File.Open(FileName, FileMode.OpenOrCreate))
                {
                    Console.WriteLine($"File '{FileName}' created successfully");
                }
            }
		}
        catch (UnauthorizedAccessException e)
        {
            throw new UIException($"Unauthorized access to file '{FileName}'.\n Details: {e.Message}");
        }
        catch (ArgumentException e)
        {
            throw new UIException($"Invalid file name '{FileName}'.\n Details: {e.Message}");
        }
        catch (IOException e)
        {
            throw new UIException($"IO error while creating file '{FileName}'.\n Details: {e.Message}");
        }
        catch (Exception e)
        {
            throw new UIException($"An unexpected error occurred.\n Details: {e.Message}", ErrorType.Unknown);
        }
    }


    public void DeleteFile(string FileName)
    {
        try
        {
            if (File.Exists(Path.Join(BasePath,FileName)))
            {
                File.Delete(Path.Join(BasePath, FileName));
            }
            else
            {
                throw new UIException($"File '{FileName}' not found.");
            }
        }
        catch (UnauthorizedAccessException e)
        {
            throw new UIException($"Unauthorized access to file '{FileName}'.\n Details: {e.Message}");
        }
        catch (ArgumentException e)
        {
            throw new UIException($"Invalid file name '{FileName}'.\n Details: {e.Message}");
        }
        catch (IOException e)
        {
            throw new UIException($"IO error while deleting file '{FileName}'.\n Details: {e.Message}");
        }
        catch (Exception e)
        {
            throw new UIException($"An unexpected error occurred.\n Details: {e.Message}", ErrorType.Unknown);
        }
    }

    public void CreateFolder(string FolderName)
    {
        RealCreateFolder(Path.Combine(BasePath,FolderName));
    }

    internal void RealCreateFolder(string FolderName)
    {
        try
        {
            if (!Directory.Exists(FolderName))
            {
                Directory.CreateDirectory(FolderName);
                Console.WriteLine($"Folder '{FolderName}' created successfully.");
            }
            else
            {
                throw new UIException($"Folder '{FolderName}' already exists.");
            }
        }
        catch (UnauthorizedAccessException e)
        {
            throw new UIException($"Unauthorized access to folder '{FolderName}'.\n Details: {e.Message}");
        }
        catch (ArgumentException e)
        {
            throw new UIException($"Invalid folder name '{FolderName}'.\n Details: {e.Message}");
        }
        catch (PathTooLongException e)
        {
            throw new UIException($"The folder path '{FolderName}' is too long.\n Details: {e.Message}");
        }
        catch (IOException e)
        {
            throw new UIException($"IO error while creating folder '{FolderName}'.\n Details: {e.Message}");
        }
        catch (Exception e)
        {
            throw new UIException($"An unexpected error occurred.\n Details: {e.Message}", ErrorType.Unknown);
        }
    }
    public void UnzipFolder(string zipFilePath, string destinationFolder)
    {
		zipFilePath = Path.Combine(BasePath, zipFilePath);
		destinationFolder = Path.Combine(BasePath, destinationFolder);

		if (!File.Exists(zipFilePath))
        {
            throw new UIException($"Zip file '{zipFilePath}' does not exist.");
        }
        try
        {
            ZipFile.ExtractToDirectory(zipFilePath, destinationFolder);
        }
        catch (Exception e)
        {
            throw new UIException($"An error occurred while unzipping the file: {e.Message}");
        }
    }
    public void ZipFolder(string folderName)
    {
        string fullfolderName = Path.Join(BasePath, folderName);

		if (Directory.Exists(fullfolderName))
        {
            string zipFileName = folderName + ".zip";

            try
            {
                ZipFile.CreateFromDirectory(fullfolderName, Path.Join(BasePath, zipFileName));
                Console.WriteLine("Folder successfully zipped to: " + zipFileName);
            }
            catch (Exception e)
            {
                throw new UIException($"An unexpected error occured when zipping folder.\n Details: {e.Message}");
            }
        }
        else
        {
            throw new UIException($"The folder '{folderName}' does not exist.");
        }

    }

    public void RenameFile(String oldName, String newName)
    {
        File.Move(oldName, newName);
    }

    public void RenameFolder(String oldName, String newName)
    {
        Directory.Move(oldName, newName);
    }

    public void MoveFileToCurrDirectory(String path)
    {
        File.Move(path, Path.Join(BasePath, Path.GetFileName(path)));
    }

}