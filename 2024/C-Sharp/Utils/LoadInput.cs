using System.Text;

namespace Utils;

public static class LoadInput
{
    private static string Year { get; } = "2024";
       private static string InputDirectory { get; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + $"/Projects/Dia/Inputs/{Year}";
    private static string Path(string day) => day.EndsWith(".txt") ? InputDirectory + "/" + day : InputDirectory + "/" + day + ".txt";
    
    public static IEnumerable<string> AsLines(string day)
    {
        return File.ReadLines(Path(day)).Where(line => !string.IsNullOrWhiteSpace(line));
    }

    public static string AsText(string day)
    {
        return File.ReadAllText(Path(day));
    }

    public static char[][] AsChars(string day)
    {
        return AsLines(day).Select(x => x.ToCharArray()).ToArray();
    }
}