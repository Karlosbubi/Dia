namespace Day6;

class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadAllLines("../../../../../../Inputs/2015/Day6.txt");
        
        string part1 = Part1(input);
        string part2 = Part2(input);

        Console.WriteLine(part1);
        Console.WriteLine(part2);
    }

    static string Part1(string[] input)
    {
        LightFieldPart1 lf = new LightFieldPart1();
        List<LightCommand> commands = input.Select(s => new LightCommand(s)).ToList();
        //Console.WriteLine($"Parsed {commands.Count} commands");
        
        foreach (LightCommand command in commands)
        {
            lf.ProcessCommand(command);
        }
        
        return lf.On.ToString();
    }
    static string Part2(string[] input)
    {
        LightFieldPart2 lf = new LightFieldPart2();
        List<LightCommand> commands = input.Select(s => new LightCommand(s)).ToList();
        //Console.WriteLine($"Parsed {commands.Count} commands");
        
        foreach (LightCommand command in commands)
        {
            lf.ProcessCommand(command);
        }
        
        return lf.Brightness.ToString();
    }
}