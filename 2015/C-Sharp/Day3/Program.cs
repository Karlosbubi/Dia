namespace Day3;

class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadAllText("../../../../../../Inputs/2015/Day3.txt");

        var part1 = Part1(input);
        var part2 = Part2(input);
        
        Console.WriteLine(part1);
        Console.WriteLine(part2);
    }
    
    public static string Part1(string input)
    {
        var position = (0, 0);
        
        var visited = new HashSet<(int, int)>();
        visited.Add(position);

        foreach (char c in input.ToCharArray())
        {
            switch (c)
            {
                case '>':
                    position.Item1++;
                    break;
                case '<':
                    position.Item1--;
                    break;
                case '^':
                    position.Item2++;
                    break;
                case 'v':
                    position.Item2--;
                    break;
            }
            
            visited.Add(position);
        }
        
        return $"{visited.Count}";
    }
    public static string Part2(string input)
    {
        var position = (0, 0);
        var roboPosition = (0, 0);
        bool robo = false;
        
        var visited = new HashSet<(int, int)>();
        visited.Add(position);

        foreach (char c in input.ToCharArray())
        {
            switch (c)
            {
                case '>':
                    if (robo)
                    {
                        roboPosition.Item1++;
                    }
                    else
                    {
                        position.Item1++;
                    }
                    break;
                case '<':
                    if (robo)
                    {
                        roboPosition.Item1--;
                    }
                    else
                    {
                        position.Item1--;
                    }
                    break;
                case '^':
                    if (robo)
                    {
                        roboPosition.Item2++;
                    }
                    else
                    {
                        position.Item2++;
                    }
                    break;
                case 'v':
                    if (robo)
                    {
                        roboPosition.Item2--;
                    }
                    else
                    {
                        position.Item2--;
                    }
                    break;
            }

            visited.Add(robo ? roboPosition : position);
            robo = !robo;
        }
        
        return $"{visited.Count}";
    }
}