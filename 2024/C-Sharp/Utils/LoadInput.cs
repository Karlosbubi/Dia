using System.Text;

namespace Utils;

public static class LoadInput
{
    public static string InputDirectory { get; } = Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile) + "/Projects/Dia/Inputs/2024";

    public static IEnumerable<string> AsLines(string day)
    {
        var path = InputDirectory + "/" + day + ".txt";
        return File.ReadLines(path);
    } 
}