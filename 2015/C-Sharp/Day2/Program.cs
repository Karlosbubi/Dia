namespace Day2;

class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadAllLines("../../../../../../Inputs/2015/Day2.txt");
        
        var part1 = Part1(input);
        var part2 = Part2(input);
        
        Console.WriteLine(part1);
        Console.WriteLine(part2);
    }
    
    public static string Part1(string[] input)
    {
        var count = 0;

        foreach (string s in input)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                continue;
            }
            
            var dimensions = s.Split('x').Select(int.Parse).ToArray();
            var l = dimensions[0];
            var w = dimensions[1];
            var h = dimensions[2];
            
            var sides = new int[] {l*w, w*h, h*l};
            
            var surface = 2*sides[0] + 2*sides[1] + 2*sides[2];
            var slack = sides.Min();

            count += surface + slack;
        }

        return $"{count} sq.ft.";
    }

    public static string Part2(string[] input)
    {
        var count = 0;

        foreach (string s in input)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                continue;
            }
            
            var dimensions = s.Split('x').Select(int.Parse).ToArray();
            var l = dimensions[0];
            var w = dimensions[1];
            var h = dimensions[2];
            
            var perimeters = new int[] {2*l+2*w, 2*w+2*h, 2*h+2*l};
            var wrap = perimeters.Min();
        
            var bow = l*w*h;
            
            count += wrap + bow;
        }
        
        return $"{count} ft.";
    }
}