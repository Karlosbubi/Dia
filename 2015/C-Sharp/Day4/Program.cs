namespace Day4;

class Program
{
    static void Main(string[] args)
    {

        var input = File.ReadAllText("../../../../../../Inputs/2015/Day4.txt");

        string part1 = Part1(input);
        string part2 = Part2(input);
    
        Console.WriteLine(part1);
        Console.WriteLine(part2);
        
    }

    private static string Part1(string input)
    {
        var count = 0;

        input = input.Trim();
        var hashInput = $"{input}{count}";
        var hash = CreateMd5(hashInput);
        
        while (!hash.StartsWith("00000"))
        {
            count++;
            hashInput = $"{input}{count}";
            hash = CreateMd5(hashInput);
        }
        
        return $"{count}";
    }

    private static string Part2(string input)
    {
        var count = 0;

        input = input.Trim();
        var hashInput = $"{input}{count}";
        var hash = CreateMd5(hashInput);
        
        while (!hash.StartsWith("000000"))
        {
            count++;
            hashInput = $"{input}{count}";
            hash = CreateMd5(hashInput);
        }
        
        return $"{count}";
    }

    private static string CreateMd5(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}