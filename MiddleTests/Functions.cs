using Middle;

namespace MiddleTests;

[TestCaseOrderer("MiddleTests.TestOrder", "MiddleTests")]
public class Functions
{
    private BackFunctions FunctionHandler;

    public Functions()
    {

        FunctionHandler = new()
        {
            BasePath = Environment.CurrentDirectory
        };

		if (FunctionHandler.TryGetSaveFilePath("test_path.txt", out string p))
		{
			string d = File.ReadAllText(p);
            if (Directory.Exists(d))
            {
                FunctionHandler.BasePath = d;
            }
		}        
    }

	[Fact, Order(1)]
	public void OpenTestSetup()
	{
		string tempDirectory;
		while (true)
		{
			tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

			if (!File.Exists(tempDirectory) && !Directory.Exists(tempDirectory))
			{
				Directory.CreateDirectory(tempDirectory);
				break;
			}
		}

		if (!FunctionHandler.TryGetSaveFilePath("test_path.txt", out string p))
		{
			BackFunctions.RealCreateFile(p);
		}
		File.WriteAllText(p, tempDirectory);
        try
        {
            Directory.Delete(tempDirectory, true);
            Directory.CreateDirectory(tempDirectory);
        }
        catch
        {
            throw;
        }
	}

	[Fact, Order(2)]
    public void TestCreateFile()
    {
        FunctionHandler.CreateFile("TestFile.txt");
    }
	[Fact, Order(3)]
	public void TestAddFavorite()
	{
		FunctionHandler.AddFavorites("TestFile.txt");
	}
	[Fact, Order(3)]
    public void TestCreateFileExist()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.CreateFile("TestFile.txt");
        });
    }
    [Fact, Order(3)]
    public void TestOpenFileNotExist()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.Open("fdsjhkfdfdhjhfdsjhdfsjhfdsjhafds.rxt");
        });
    }
	[Fact, Order(4)]
	public void TestHasFavorite()
	{
		string [] tmp = FunctionHandler.GetFavorites();
        Assert.Contains(Path.Join(FunctionHandler.BasePath, "TestFile.txt"), tmp);
	}
	[Fact, Order(4)]
    public void OpenFileWith()
    {
        FunctionHandler.OpenWith(FunctionHandler.GetProgram("TestFile.txt")!, "TestFile.txt");
    }
    [Fact, Order(5)]
    public void OpenFile()
    {
        FunctionHandler.Open("TestFile.txt");
    }

    [Fact, Order(6)]
    public void TestDeleteFile()
    {
        FunctionHandler.DeleteFile("TestFile.txt");
    }

    [Fact, Order(7)]
    public void TestCreateFolder()
    {
        FunctionHandler.CreateFolder("Folder1");
    }
    [Fact, Order(9)]
    public void TestZipFolderDoesNotExist()
    {
        Assert.Throws<UIException>(() =>
        {
            FunctionHandler.ZipFolder("NonExistentFolder");
        });
    }
    [Fact, Order(10)]
    public void TestZipFolderSuccess()
    {
        FunctionHandler.CreateFolder("FolderToZip");

        FunctionHandler.ZipFolder("FolderToZip");

        FunctionHandler.DeleteFile("FolderToZip.zip");
    }

}