namespace Day5;

class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadAllLines("../../../../../../Inputs/2015/Day5.txt");

        string part1 = Part1(input);
        string part2 = Part2(input);

        Console.WriteLine(part1);
        Console.WriteLine(part2);
    }

    private static string Part1(string[] input)
    {
        var count = 0;

        foreach (string s in input)
        {
            if(s.Contains("ab") || s.Contains("cd") || s.Contains("pq") || s.Contains("xy"))
            {
                continue; // Contains forbidden strings
            }

            if (s.ToCharArray().Count(c => "aeiou".Contains(c)) < 3)
            {
                continue; // Less than 3 vowels
            }
            
            var hasDouble = false;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    hasDouble = true;
                    break;
                }
            }

            if (hasDouble)
            {
                count++;
            }
        }
        
        return $"{count}";
    }
    
    private static string Part2(string[] input)
    {
        var count = 0;

        foreach (string s in input)
        {
            var hasPair = false;
            for (int i = 0; i < s.Length - 1; i++)
            {
                var pair = $"{s[i]}{s[i + 1]}";
                if (s.IndexOf(pair, i + 2) != -1)
                {
                    hasPair = true;
                    break;
                }
            }

            if (!hasPair)
            {
                continue;
            }

            var hasRepeat = false;
            for (int i = 0; i < s.Length - 2; i++)
            {
                if (s[i] == s[i + 2])
                {
                    hasRepeat = true;
                    break;
                }
            }

            if (hasRepeat)
            {
                count++;
            }
        }

        return $"{count}";
    }
}