using Middle;

namespace MiddleTests;

public class Functions
{
    private BackFunctions FunctionHandler;

    public Functions()
    {
        string tempDirectory;
        while (true)
        {
            tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            if(!File.Exists(tempDirectory) && !Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
                break;
            }
        }

        FunctionHandler = new()
        {
            BasePath = tempDirectory
        };
    }
    
    [Fact]
    public void testCreate()
    {
        FunctionHandler.CreateFile("TestFile.txt");
    }
    [Fact]
    public void OpenFileWith()
    {
        FunctionHandler.OpenWith(FunctionHandler.GetProgram("TestFile.txt")!, "TestFile.txt");
    }
    [Fact]
    public void OpenFile()
    {
        FunctionHandler.Open("TestFile.txt");
    }

    [Fact]
    public void testDelete()
    {
        FunctionHandler.DeleteFile("TestFile.txt");
    }

    [Fact]
    public void testCreateFolder()
    {
        FunctionHandler.CreateFolder("Folder1");
    }
}