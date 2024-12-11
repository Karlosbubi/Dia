// See https://aka.ms/new-console-template for more information

using Utils;

Console.WriteLine("Hello, World!");
var cache = new Dictionary<(ulong stone, ulong n), decimal>();

var test = false;
var input = @"125 17".Split(" ")
.Where(x => !string.IsNullOrWhiteSpace(x))
.Select(ulong.Parse).ToArray();
if (!test)
{
    input = LoadInput.AsText("Day11")
        .Split(" ")
        .Where(x => !string.IsNullOrWhiteSpace(x))
        .Select(x => ulong.Parse(x.Trim())).ToArray();
}

//Console.WriteLine(String.Join(" ", input));
//Console.WriteLine(String.Join(" ", BlinkN(input, 1)));
//Console.WriteLine(String.Join(" ", BlinkN(input, 2)));

var part1 = BlinkN(input, 25);
Console.WriteLine($"Part 1: {part1}");

var part2 = BlinkN(input, 75);
Console.WriteLine($"Part 2: {part2}");
return;


decimal BlinkN(IEnumerable<ulong> stones, uint count)
{
    return stones.Select(x => Blink1N(x, count)).Sum();
}

decimal Blink1N(ulong stone, uint count)
{
    if (cache.ContainsKey((stone, count)))
    {
        return cache[(stone, count)];
    }

    var res = count == 0 ? 1 : BlinkN(Blink1(stone), count - 1);
    cache.Add((stone, count), res);
    return res;
}

IEnumerable<ulong> Blink1(ulong stone)
{
    if (stone == 0)
    {
       yield return 1;
       yield break;
    }
        
    var s = stone.ToString();
    var l = s.Length;
    if (l % 2 == 0)
    {
        var s1 = s[..(l / 2)];
        var s2 = s[(l / 2)..];
        //Console.WriteLine($"{s} : {s1} + {s2}");
        yield return uint.Parse(s1);
        yield return uint.Parse(s2);
        yield break;
    }

    yield return stone * 2024;
}

IEnumerable<ulong> Blink(IEnumerable<ulong> stones)
{
    return stones.SelectMany(Blink1);
}