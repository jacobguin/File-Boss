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
    [Fact, Order(1)]
    public void TestCreateFileExist()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.CreateFile("TestFile.txt");
        });
    }
    [Fact, Order(1)]
    public void TestInvalidFileName()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.CreateFile("..");
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
    [Fact, Order(2)]
    public void TestOpenWithProgramDontExist()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.OpenWith("billybobx32.elf", "TestFile.txt");
        });
    }
    [Fact, Order(2)]
    public void TestOpenWithFileDontExist()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.OpenWith(FunctionHandler.GetProgram("TestFile.txt")!, "dennis.txt");
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
    [Fact, Order(5)]
    public void TestDeleteDoesNotExist()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.DeleteFile("fjdaskfjdsakf.rgy");
        });
    }

    [Fact, Order(6)]
    public void testCreateFolder()
    {
        FunctionHandler.CreateFolder("Folder1");
    }
    [Fact, Order(7)]
    public void TestFolderAlreadyExist()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.CreateFolder("Folder1");
        });
    }
    [Fact, Order(6)]
    public void TestInvalidFolderName()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.CreateFolder("../ \\ : ? * \" < > |");
        });
    }
    [Fact, Order(8)]
    public void CleanUp()
    {
        Directory.Delete("Folder1");
    }
}