using System.ComponentModel;
using System.Diagnostics;

namespace Middle;

public static class BackFunctions
{
    /// <summary>
    /// Testing Dictionary for function will be moved config files after the the user can update it in the UI
    /// </summary>
    public static Dictionary<string, string> ProgramMap = new();//Testing for now

    public static void LoadMaps()
    {
        ProgramMap.Clear();
        if (OperatingSystem.IsWindows())
        {
            ProgramMap.Add(".txt", "notepad.exe");
        }
        else
        {
            ProgramMap.Add(".txt", "gnome-text-editor");
        }
    }

    public static void Open(string FileToOpen)
    {
        try
        {
            FileInfo FI = new FileInfo(FileToOpen);

            if (ProgramMap.TryGetValue(FI.Extension.ToLower(), out string Program))
            {
                OpenWith(Program, FileToOpen);
                return;
            }
            Process.Start(FileToOpen);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Error: The file '{FileToOpen}' was not found. Details: {e.Message}");
        }
        
        catch (Win32Exception e)
        {
            Console.WriteLine($"Error: There was a problem starting the file '{FileToOpen}'. Details: {e.Message}");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"Error: Invalid operation while trying to open '{FileToOpen}'. Details: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: An unexpected error occurred while trying to open '{FileToOpen}'. Details: {e.Message}");
        }
    }


    public static void OpenWith(string Program, string FileToOpen)
    {
        try
        {
            Process p = new Process()
            {
                StartInfo =
            {
                FileName = Program,
                Arguments = FileToOpen
            }
            };
            _ = p.Start();
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine($"Error: Program '{Program}' not found. Details: {e.Message}");
        }
        catch (Win32Exception e)
        {
            Console.WriteLine($"Error: There was a problem starting the program '{Program}'. Details: {e.Message}");
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"Error: The process start info is invalid. Details: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: An unexpected error occurred while trying to open '{FileToOpen}' with '{Program}'. Details: {e.Message}");
        }
    }


    public static void CreateFile(string FileName)
    {
        try
        {
            if (File.Exists(FileName))
            {
                Console.WriteLine($"File '{FileName}' already exists");
            }
            else
            {
                using (var fs = File.Open(FileName, FileMode.OpenOrCreate))
                {
                    Console.WriteLine($"File '{FileName}' created successfully");
                }
            }
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine($"Error: Unauthorized access to file '{FileName}'. Details: {e.Message}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Error: Invalid file name '{FileName}'. Details: {e.Message}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error: IO error while creating file '{FileName}'. Details: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: An unexpected error occurred. Details: {e.Message}");
        }
    }


    public static void DeleteFile(string FileName)
    {
        try
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
                Console.WriteLine($"File '{FileName}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"File '{FileName}' not found.");
            }
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine($"Error: Unauthorized access to file '{FileName}'. Details: {e.Message}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Error: Invalid file name '{FileName}'. Details: {e.Message}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error: IO error while deleting file '{FileName}'. Details: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: An unexpected error occurred. Details: {e.Message}");
        }
    }


    public static void CreateFolder(string FolderName)
    {
        try
        {
            if (!Directory.Exists(FolderName))
            {
                Directory.CreateDirectory(FolderName);
                Console.WriteLine($"Folder '{FolderName}' created successfully.");
            }
            if (Directory.Exists(FolderName))
            {
                Console.WriteLine($"Folder '{FolderName}' already exists.");
            }
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine($"Error: Unauthorized access to folder '{FolderName}'. Details: {e.Message}");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"Error: Invalid folder name '{FolderName}'. Details: {e.Message}");
        }
        catch (PathTooLongException e)
        {
            Console.WriteLine($"Error: The folder path '{FolderName}' is too long. Details: {e.Message}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error: IO error while creating folder '{FolderName}'. Details: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: An unexpected error occurred. Details: {e.Message}");
        }
    }


}