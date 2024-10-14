using Middle;

namespace MiddleTests;

public class Functions
{
    [Fact]
    public void FunctionMaps()
    {
        BackFunctions.LoadMaps();
    }
    [Fact]
    public void OpenFileWith()
    {
        BackFunctions.OpenWith("notepad.exe", "C:\\Users\\clayp\\Downloads\\Test.txt");
    }
    [Fact]
    public void OpenFile()
    {
        BackFunctions.Open("C:\\Users\\clayp\\Downloads\\Test.txt");
    }

    [Fact]
    public void testCreate()
    {
        BackFunctions.CreateFile("TestFile.txt");
    }

    [Fact]
    public void testDelete()
    {
        BackFunctions.DeleteFile("TestFile.txt");
    }

    [Fact]
    public void testCreateFolder()
    {
        BackFunctions.CreateFolder("Folder1");
    }
}