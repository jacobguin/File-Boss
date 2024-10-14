using System.Diagnostics;

namespace Middle;

public static class BackFunctions
{
    /// <summary>
    /// Testing Dictionary for function will be moved config files after the the user can update it in the UI
    /// </summary>
    public static Dictionary<string, string> ProgramMap = new()//Testing for now
    {
#if WINDOWS
        {"txt", "notepad.exe"}
#else 
        {".txt", "gnome-text-editor"}
#endif
    };

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
}