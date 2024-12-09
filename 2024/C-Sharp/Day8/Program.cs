// See https://aka.ms/new-console-template for more information

using Utils;
using static Utils.Extensions;

Console.WriteLine("Hello, World!");

var test = false;
var debug = false;

var input = @"............
........0...
.....0......
.......0....
....0.......
......A.....
............
............
........A...
.........A..
............
............".Split('\n').Select(x => x.Trim().ToCharArray()).ToArray();

if (!test)
{
    input = LoadInput.AsChars("Day8");
}

var rows = input.Length;
var cols = input.First().Length;
var radios = new Dictionary<char, List<(int x, int y)>>();

foreach (var line in input.Select((l, y) => (l, y)))
{
    foreach (var radio in line.l.Select(((c, x) => (c, x, line.y))))
    {
        if (radio.c.Equals('.'))
        {
            continue;
        }

        if (!radios.ContainsKey(radio.c))
        {
            radios.Add(radio.c, new List<(int x, int y)>());
        }

        if (debug)
        {
            Console.WriteLine($"Radio '{radio.c}' has a location at {radio.x}, {radio.y}");
        }

        radios[radio.c].Add((radio.x, radio.y));
    }
}

var antinodes = new List<(int x, int y)>();
foreach (var radio in radios)
{
    if (debug)
    {
        Console.WriteLine($"Analyzing radio '{radio.Key}'");
    }

    var chunks = radio.Value.Subsets(2).Select(x => x.ToArray());
    foreach (var chunk in chunks)
    {
        var (x1, y1) = chunk[0];
        var (x2, y2) = chunk[1];

        if ((x1, y1) == (x2, y2))
        {
            continue;
        }

        var (dx, dy) = (x2 - x1, y2 - y1);
        if (debug)
        {
            Console.WriteLine($"Stations: ({x1}, {y1}), ({x2}, {y2})");
            Console.WriteLine($"Dx: {dx}, Dy: {dy}");
            Console.WriteLine($"Antinodes: ({x1 - dx}, {y1 - dy}), ({x2 + dx}, {y2 + dy})");
        }

        antinodes.Add((x1 - dx, y1 - dy));
        antinodes.Add((x2 + dx, y2 + dy));
    }
}

var part1 = antinodes.Distinct().Count(n => n.x < rows && n.y < cols && n.x >= 0 && n.y >= 0);
Console.WriteLine($"Part 1: {part1}");

antinodes = new List<(int x, int y)>();
foreach (var radio in radios)
{
    if (debug)
    {
        Console.WriteLine($"Analyzing radio '{radio.Key}'");
    }

    var chunks = radio.Value.Subsets(2).Select(x => x.ToArray());
    foreach (var chunk in chunks)
    {
        var (x1, y1) = chunk[0];
        var (x2, y2) = chunk[1];

        if ((x1, y1) == (x2, y2))
        {
            continue;
        }

        var (dx, dy) = (x2 - x1, y2 - y1);
        if (debug)
        {
            Console.WriteLine($"Stations: ({x1}, {y1}), ({x2}, {y2})");
            Console.WriteLine($"Dx: {dx}, Dy: {dy}");
            Console.Write($"Antinodes: ({x1}, {y1}), ({x2}, {y2}) ");
        }

        var (xn, yn) = (x1, y1);
        while (xn < rows && yn < cols && xn >= 0 && yn >= 0)
        {
            antinodes.Add((xn, yn));
            if (debug)
            {
                Console.Write($"({xn}, {yn})");
            }

            xn -= dx;
            yn -= dy;
        }

        (xn, yn) = (x2, y2);
        while (xn < rows && yn < cols && xn >= 0 && yn >= 0)
        {
            antinodes.Add((xn, yn));
            if (debug)
            {
                Console.Write($"({xn}, {yn})");
            }

            xn += dx;
            yn += dy;
        }

        if (debug)
        {
            Console.WriteLine();
        }
    }
}

var part2 = antinodes.Distinct().Count(n => n.x < rows && n.y < cols && n.x >= 0 && n.y >= 0);
Console.WriteLine($"Part 1: {part2}");