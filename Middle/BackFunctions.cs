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
        FileInfo FI = new FileInfo(FileToOpen);
        
        if (ProgramMap.TryGetValue(FI.Extension.ToLower(), out string Program))
        {
            OpenWith(Program, FileToOpen);
            return;
        }
        Process.Start(FileToOpen);
    }
    
    public static void OpenWith(string Program, string FileToOpen)
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

    public static void CreateFile(string FileName)
    {
        if (File.Exists(FileName))
        {
            Console.WriteLine($"File '{FileName}' already exists");
        }

        else
        {
            using (var fs = File.Open(FileName, FileMode.OpenOrCreate))
            {
            }

            Console.WriteLine($"File '{FileName}' created successfully");
        }

    }

    public static void DeleteFile(string FileName)
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

    public static void CreateFolder(string FolderName)
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

}