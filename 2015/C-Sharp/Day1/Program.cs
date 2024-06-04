namespace Day1;

class Program
{
    static void Main()
    {
        var input = File.ReadAllText("../../../../../../Inputs/2015/Day1.txt");

        var part1 = Part1(input);
        var part2 = Part2(input);
        
        Console.WriteLine(part1);
        Console.WriteLine(part2);
    }
    
    public static string Part1(string input)
    {
        var count = 0;

        foreach (var c in input.ToCharArray())
        {
            if (c == '(')
            {
                count++;
            }
            else if (c == ')')
            {
                count--;
            }
        }
        
        return count.ToString();
    }
    
    public static string Part2(string input)
    {
        var count = 0;
        var position = 0;

        foreach (var c in input.ToCharArray())
        {
            position++;
            if (c == '(')
            {
                count++;
            }
            else if (c == ')')
            {
                count--;
            }
            
            if (count == -1)
            {
                return position.ToString();
            }
        }
        
        return "Not found";
    }
}