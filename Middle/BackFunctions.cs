using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Collections.Specialized;
using System.Text.Json.Serialization.Metadata;
using System.Text.Json;

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
        UILinks.Push(UndoCode.Count - 1);
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

	public void SaveSettings<TResult>(string name, TResult json, JsonTypeInfo<TResult> TypeInfo) where TResult : new()
	{
        _ = TryGetSaveFilePath(name, out string path);
		File.WriteAllText(path, JsonSerializer.Serialize(json, TypeInfo));
	}

	public TResult GetSettings<TResult>(string name, JsonTypeInfo<TResult> TypeInfo) where TResult : new()
	{
		TResult? @out;
		if (!TryGetSaveFilePath(name, out string path))
		{
			@out = new();
			File.WriteAllText(path, JsonSerializer.Serialize(@out, TypeInfo));
		}

		try
		{
			@out = JsonSerializer.Deserialize(File.ReadAllText(path), TypeInfo);
			if (@out is null)
			{
				@out = new();
			}
		}
		catch
		{
			@out = new();
		}
		File.WriteAllText(path, JsonSerializer.Serialize(@out, TypeInfo));
		return @out;
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
            string tmp = (string)bp.Clone();

			UndoCode.Push(() => 
            {
                bp = tmp; 
            });

            bp = value;
        }
    }

    public void Open(string FileToOpen)
    {
        try
        {
            if (!File.Exists(Path.Join(BasePath,FileToOpen))) throw new UIException("The provided file is not valid");
            FileInfo FI = new FileInfo(FileToOpen);

            if (ProgramMap.TryGetValue(FI.Extension.ToLower(), out string? Program))
            {
                OpenWith(Program, FileToOpen);
                return;
            }
			Process.Start(new ProcessStartInfo(Path.Join(BasePath, FileToOpen)) { UseShellExecute = true });
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

    public void DeleteFilesAndFolders(StringCollection paths)
    {
        try
        {
            foreach (string p in paths)
            {
				if (File.Exists(p)) File.Delete(p);
				if (Directory.Exists(p))
                {
                    Directory.Delete(p, true);
                }
            }
        }
        catch
        { }
    }

    public void PastFilesAndFolders(StringCollection paths)
    {
        StringCollection s = new();
		foreach (var f in paths)
		{
            if (string.IsNullOrWhiteSpace(f)) continue;
			if (!File.Exists(f) && !Directory.Exists(f)) continue;
            if (File.Exists(f))
            {
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
							withnum(i + 1);
						}
						else
						{
							name += $" ({i}){ext}";
						}
					}
					withnum(1);
				}
                s.Add(Path.Join(BasePath, name));
				File.Copy(f, Path.Join(BasePath, name));
			}
            else
            {
				DirectoryInfo old = new(f);
				string name = old.Name;
				if (Directory.Exists(Path.Join(BasePath, name)))
				{
					void withnum(int i)
					{
						if (Directory.Exists(Path.Join(BasePath, name + $" ({i})")))
						{
							withnum(i + 1);
						}
						else
						{
							name += $" ({i})";
						}
					}
					withnum(1);
				}
				s.Add(Path.Join(BasePath, name));
				CopyDirectory(old.FullName, Path.Join(BasePath, name));
			}
		}
        UndoCode.Push(() => { DeleteFilesAndFolders(s); });
	}

	private void CopyDirectory(string sourceDir, string destinationDir)
	{
		Directory.CreateDirectory(destinationDir);

		foreach (var filePath in Directory.GetFiles(sourceDir))
		{
			var fileName = Path.GetFileName(filePath);
			var destinationFilePath = Path.Combine(destinationDir, fileName);
			File.Copy(filePath, destinationFilePath);
		}

		foreach (var dirPath in Directory.GetDirectories(sourceDir))
		{
			var dirName = Path.GetFileName(dirPath);
			var destinationSubDir = Path.Combine(destinationDir, dirName);
			CopyDirectory(dirPath, destinationSubDir);
		}
	}

	public void OpenWith(string Program, string FileToOpen)
    {
        try
        {
            if (!File.Exists(Path.Join(BasePath, FileToOpen))) throw new UIException("The provided file is not valid");
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
            if (File.Exists(Path.Join(BasePath, FileName)))
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
        RealCreateFolder(Path.Combine(BasePath, FolderName));
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
    public void CreateFileShortcut(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                throw new UIException("The provided file path does not exist.");
            }
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string shortcutName = Path.GetFileNameWithoutExtension(filePath);

            string shortcutPath = Path.Combine(desktopPath, $"{shortcutName}.url");

            if (File.Exists(shortcutPath))
            {
                throw new UIException($"Shortcut '{shortcutName}.url' already exists on the desktop.");
            }

            using (StreamWriter writer = new StreamWriter(shortcutPath))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine($"URL=file:///{filePath.Replace("\\", "/")}");
            }

            Console.WriteLine($"Shortcut '{shortcutName}.url' created on the desktop successfully.");

        }
        catch (UnauthorizedAccessException e)
        {
            throw new UIException($"Unauthorized access while creating the shortcut for '{filePath}'.\nDetails: {e.Message}");
        }
        catch (IOException e)
        {
            throw new UIException($"IO error while creating the shortcut for '{filePath}'.\nDetails: {e.Message}");
        }
        catch (Exception e)
        {
            throw new UIException($"An unexpected error occurred while creating the shortcut for '{filePath}'.\nDetails: {e.Message}", ErrorType.Unknown);
        }
    }
    //Hawk Tuah
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

	private void AddDirectoryToArchive(ZipArchive archive, string sourceDir, string baseDir)
	{
		foreach (string filePath in Directory.GetFiles(sourceDir, "*", SearchOption.AllDirectories))
		{
			string relativePath = Path.Join(baseDir, Path.GetRelativePath(sourceDir, filePath));
			archive.CreateEntryFromFile(filePath, relativePath);
		}
	}

	public void ZipData(string zip, params string[] folderandfileNames)
    {
        string zippath = Path.Join(BasePath, zip);
        if (File.Exists(zippath)) throw new UIException($"Zip file '{zip}' already exist.");

        ZipArchive archive = ZipFile.Open(zippath, ZipArchiveMode.Create);

		foreach (string fileName in folderandfileNames)
		{
			string path = Path.Join(BasePath, fileName);
			if (File.Exists(path))
			{
				archive.CreateEntryFromFile(path, fileName);
			}
			else if (Directory.Exists(path))
			{
				AddDirectoryToArchive(archive, path, fileName);
			}
		}
        archive.Dispose();
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
        File.Move(Path.Join(BasePath, oldName), Path.Join(BasePath, newName));
        UndoCode.Push(() => { File.Move(Path.Join(BasePath, newName), Path.Join(BasePath, oldName)); });
    }

    public void RenameFolder(String oldName, String newName)
    {
        Directory.Move(Path.Join(BasePath, oldName), Path.Join(BasePath, newName));
		UndoCode.Push(() => { Directory.Move(Path.Join(BasePath, newName), Path.Join(BasePath, oldName)); });
	}

    public void MoveFileToCurrDirectory(String path)
    {
        File.Move(path, Path.Join(BasePath, Path.GetFileName(path)));
    }

    public void DeleteFolder(string folderName)
    {
        string folderPath = Path.Combine(BasePath, folderName);

        try
        {
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
                Console.WriteLine($"Folder '{folderName}' deleted successfully.");
            }
            else
            {
                throw new UIException($"Folder '{folderName}' not found.");
            }
        }
        catch (UnauthorizedAccessException e)
        {
            throw new UIException($"Unauthorized access to folder '{folderName}'.\nDetails: {e.Message}");
        }
        catch (DirectoryNotFoundException e)
        {
            throw new UIException($"Folder '{folderName}' not found.\nDetails: {e.Message}");
        }
        catch (IOException e)
        {
            throw new UIException($"IO error while deleting folder '{folderName}'.\nDetails: {e.Message}");
        }
    }
    public List<string> SearchFilesAndDirectories(string currentDirectory, string searchPattern = "*.*")
    {
        var result = new List<string>();

        try
        {
            foreach (var file in Directory.GetFiles(currentDirectory, searchPattern))
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);

                if (fileNameWithoutExtension.Contains(searchPattern.Trim('*'), StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(file);
                }
            }

            foreach (var dir in Directory.GetDirectories(currentDirectory))
            {
               // result.AddRange(SearchFilesAndDirectories(dir, searchPattern));
            }
        }
        catch (UnauthorizedAccessException e)
        {
            throw new UIException($"Access denied to '{currentDirectory}'.\nDetails: {e.Message}");
        }
        catch (Exception e)
        {
            throw new UIException($"Error searching in directory {currentDirectory}: {e.Message}");
        }

        return result;
    }
}
