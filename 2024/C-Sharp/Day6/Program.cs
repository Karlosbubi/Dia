// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Serilog;
using Serilog.Core;
using Utils;

using var log = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().CreateLogger();

var test = false;

Console.WriteLine("Hello, World!");
var input = @"
....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...
".Split('\n').Where(x => !string.IsNullOrWhiteSpace(x))
    .Select(x => x.Trim().ToCharArray()).ToArray();
if (!test)
{
    input = LoadInput.AsChars("Day6");
}

var rows = input.Length;
var cols = input.First().Length;
log.Debug($"rows: {rows}, cols: {cols}");

(int x, int y) initialPosition = input
    .Select((l, i) => (l, i))
    .Where(x => x.l.Contains('^'))
    .Select((x, i) => (x.i, x.l.Select((l, j) => (l, j)).First(x => x.l == '^').j))
    .Single();

log.Debug($"starting position: {initialPosition}");

var map = Transform.ConvertTo2D(input);

var part1 = ComputeMap(map, initialPosition);
if (!part1.exits)
{
    throw new Exception("Part 1 failed!");
}
log.Warning($"Part1 : {part1.visited.Match(visited => visited, () => 0)}");

// F*** it, just Bruteforce.
var spots = part1.spots;
var part2 = GernerateMaps(map, spots, log).Select(m => ComputeMap(m, initialPosition)).Count(x => !x.exits);
log.Warning($"Part2 : {part2}");

return;


(bool exits, Option<int> visited, List<State> spots) ComputeMap(char[,] mapToCompute, (int x, int y) startingPosition)
{
    log.Debug($"map starting position: {startingPosition}");
    var position = startingPosition;
    var direction = Direction.Up;
    var visited = new List<State>();
    var looped = false;
    while ((position.x + 1 < rows && position.x > 0 && position.y + 1 < cols && position.y > 0) && !looped)
    {
        switch (direction)
        {
            case Direction.Left:
                if (mapToCompute[position.x, position.y - 1] == '#')
                {
                    direction = Direction.Up;
                }
                else
                {
                    position.y--;
                }

                break;
            case Direction.Down:
                if (mapToCompute[position.x + 1, position.y] == '#')
                {
                    direction = Direction.Left;
                }
                else
                {
                    position.x++;
                }

                break;
            case Direction.Right:
                if (mapToCompute[position.x, position.y + 1] == '#')
                {
                    direction = Direction.Down;
                }
                else
                {
                    position.y++;
                }

                break;
            case Direction.Up:
                if (mapToCompute[position.x - 1, position.y] == '#')
                {
                    direction = Direction.Right;
                }
                else
                {
                    position.x--;
                }

                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        var v = new State(X: position.x, Y: position.y, Direction: direction);
        
        log.Debug(v.ToString());
        if (visited.Contains(v))
        {
            looped = true;
            log.Debug(v.ToString());
        }
        visited.Add(v);
    }

    var visitedCount = visited.Select(s => (s.X, s.Y)).Distinct().Count();

    return looped ? (false, Option<int>.None(), visited) : (true, Option<int>.Some(visitedCount), visited);
}

IEnumerable<char[,]> GernerateMaps(char[,] baseMap, List<State> baseSpots, Logger logger)
{
    var todo = baseSpots.Select(s => (s.X, s.Y)).Distinct()
        .Where(x => !(x.X == initialPosition.x && x.Y == initialPosition.y))
        .Where(x => baseMap[x.X, x.Y] != '#');
        
    foreach (var s in todo)     
    {
        var newMap = baseMap.Clone() as char[,];
        if (newMap == null) continue;
        newMap[s.X, s.Y] = '#';
        yield return newMap;
    }
}

void PrintMap(char[,] mapToPrint)
{
    var rowsToPrint = mapToPrint.GetLength(0);
    var colsToPrint = mapToPrint.GetLength(1);

    for (var i = 0; i < rowsToPrint; i++)
    {
        for (var j = 0; j < colsToPrint; j++)
        {
            Console.Write(mapToPrint[i, j]);
        }

        Console.WriteLine();
    }
}

enum Direction
{
    Up,
    Down,
    Left,
    Right
}

record struct State(Direction Direction, int Y, int X)
{
}