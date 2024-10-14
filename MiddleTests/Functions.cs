using Middle;

namespace MiddleTests;

public class Functions
{
    [Fact]
    public void OpenFileWith()
    {
        BackFunctions.OpenWith("gnome-text-editor", "/home/jacob/Documents/ggg.txt");
    }
    [Fact]
    public void OpenFile()
    {
        BackFunctions.Open("/home/jacob/Documents/ggg.txt");
    }
}