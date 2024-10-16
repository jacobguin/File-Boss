using System.Diagnostics;

namespace Middle;

public class BackFunctions
{
    /// <summary>
    /// Testing Dictionary for function will be moved config files after the the user can update it in the UI
    /// </summary>
    public Dictionary<string, string> ProgramMap = new();//Testing for now

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

    public string? GetProgram(string FileName)
    {
        FileInfo FI = new FileInfo(FileName);
        if (ProgramMap.TryGetValue(FI.Extension.ToLower(), out string? Program)) return Program;
        return null;
    }
    
    public required string BasePath { get; set; }

    public void Open(string FileToOpen)
    {
        FileToOpen = Path.Combine(BasePath, FileToOpen);
        FileInfo FI = new FileInfo(FileToOpen);
        
        if (ProgramMap.TryGetValue(FI.Extension.ToLower(), out string Program))
        {
            OpenWith(Program, FileToOpen);
            return;
        }
        Process.Start(FileToOpen);
    }
    
    public void OpenWith(string Program, string FileToOpen)
    {
        FileToOpen = Path.Combine(BasePath, FileToOpen);
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

    public void CreateFile(string FileName)
    {
        FileName = Path.Combine(BasePath, FileName);
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

    public void DeleteFile(string FileName)
    {
        FileName = Path.Combine(BasePath, FileName);
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

    public void CreateFolder(string FolderName)
    {
        FolderName = Path.Combine(BasePath, FolderName);
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