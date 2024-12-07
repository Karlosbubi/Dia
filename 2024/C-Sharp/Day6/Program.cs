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
var spots = (rows * cols) - 1;
var spotCounter = 0;

log.Debug($"rows: {rows}, cols: {cols}, spots: {spots} ");


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
spotCounter = 0;
var part2 = GernerateMaps(map, log).Select(m => ComputeMap(m, initialPosition)).Count(x => !x.exits);
log.Warning($"Part2 : {part2}");


return;


(bool exits, Option<int> visited) ComputeMap(char[,] mapToCompute, (int x, int y) startingPosition)
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


    
    spotCounter++;
    log.Information($"Computed map: {spotCounter}/{spots} ({(((float)spotCounter / (float)spots) * 100.0):F3}%)");
    log.Information($"Map exited : {!looped}" + (looped ? "" : $", visited : {visitedCount}"));

    return looped ? (false, Option<int>.None()) : (true, Option<int>.Some(visitedCount));
}

IEnumerable<char[,]> GernerateMaps(char[,] baseMap, Logger logger)
{
    for (var i = 0; i < baseMap.GetLength(0); i++)
    {
        for (var j = 0; j < baseMap.GetLength(1); j++)
        {
            switch (baseMap[i, j])
            {
                case '^':
                    continue;
                case '#':
                    spotCounter++;
                    logger.Information($"Skipped map: {spotCounter}: {i}, {j} already obstruced");
                    continue;
                default:
                    var newMap = baseMap.Clone() as char[,];
                    if (newMap == null) continue;
                    newMap[i, j] = '#';
                    yield return newMap;
                    break;
            }
        }
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