using Middle;

namespace MiddleTests;

[TestCaseOrderer("MiddleTests.TestOrder", "MiddleTests")]
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
    
    [Fact, Order(1)]
    public void TestCreateFile()
    {
        FunctionHandler.CreateFile("TestFile.txt");
    }
    [Fact, Order(2)]
    public void TestCreateFileExist()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.CreateFile("TestFile.txt");
        });
    }
    [Fact, Order(2)]
    public void TestOpenFileNotExist()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.Open("fdsjhkfdfdhjhfdsjhdfsjhfdsjhafds.rxt");
        });
    }
    [Fact, Order(3)]
    public void OpenFileWith()
    {
        FunctionHandler.OpenWith(FunctionHandler.GetProgram("TestFile.txt")!, "TestFile.txt");
    }
    [Fact, Order(4)]
    public void OpenFile()
    {
        FunctionHandler.Open("TestFile.txt");
    }

    [Fact, Order(5)]
    public void testDelete()
    {
        FunctionHandler.DeleteFile("TestFile.txt");
    }

    [Fact, Order(6)]
    public void testCreateFolder()
    {
        FunctionHandler.CreateFolder("Folder1");
    }
}