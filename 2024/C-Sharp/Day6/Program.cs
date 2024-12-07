// See https://aka.ms/new-console-template for more information

using Utils;

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

// input = LoadInput.AsChars("Day6");

var rows = input.Length;
var cols = input.First().Length;

//Console.WriteLine($"rows: {rows}, cols: {cols} ");

var visited = new bool[rows, cols];

(int x, int y) position = input
    .Select((l, i) => (l, i))
    .Where(x => x.l.Contains('^'))
    .Select((x, i) => (x.i, x.l.Select((l, j) => (l, j)).First(x => x.l == '^').j))
    .Single();
//Console.WriteLine($"position: {position}");
Direction direction = Direction.Up;
var map = Transform.ConvertTo2D(input);
visited[position.x, position.y] = true;
while (position.x + 1 < rows && position.x > 0 && position.y + 1 < cols && position.y > 0)
{
    switch (direction)
    {
        case Direction.Left:
            if (map[position.x, position.y - 1] == '#')
            {
                direction = Direction.Up;
            }
            else
            {
                position.y--;
            }
            break;
        case Direction.Down:
            if (map[position.x + 1, position.y] == '#')
            {
                direction = Direction.Left;
            }
            else
            {
                position.x++;
            }
            break;
        case Direction.Right:
            if (map[position.x, position.y + 1] == '#')
            {
                direction = Direction.Down;
            }
            else
            {
                position.y++;
            }
            break;
        case Direction.Up:
            if (map[position.x - 1, position.y] == '#')
            {
                direction = Direction.Right;
            }
            else
            {
                position.x--;
            }
            break;
        default:
            throw new ArgumentOutOfRangeException
            {
                HelpLink = null,
                HResult = 0,
                Source = null
            };
    }
    visited[position.x, position.y] = true;
    map[position.x, position.y] = 'X';
    //PrintMap(map);
}

var visitedT = Transform.ConvertFrom2D(visited);
var visitedC = visitedT.Select(x => x.Count(y => y)).Sum();
Console.WriteLine($"Part1 : {visitedC}");

var obstructed = new bool[rows, cols];
var states = new List<State>();
while (position.x + 1 < rows && position.x > 0 && position.y + 1 < cols && position.y > 0)
{
    switch (direction)
    {
        case Direction.Left:
            if (map[position.x, position.y - 1] == '#')
            {
                direction = Direction.Up;
            }
            else
            {
                var hypothetical = new State(X: position.x, Y: position.y, Direction: Direction.Up);
                if (states.Any(x => x.Equals(hypothetical)))
                {
                    obstructed[position.x, position.y - 1] = true;
                }
                position.y--;
            }
            break;
        case Direction.Down:
            if (map[position.x + 1, position.y] == '#')
            {
                direction = Direction.Left;
            }
            else
            {
                var hypothetical = new State(X: position.x, Y: position.y, Direction: Direction.Left);
                if (states.Any(x => x.Equals(hypothetical)))
                {
                    obstructed[position.x + 1, position.y] = true;
                }
                position.x++;
            }
            break;
        case Direction.Right:
            if (map[position.x, position.y + 1] == '#')
            {
                direction = Direction.Down;
            }
            else
            {
                var hypothetical = new State(X: position.x, Y: position.y, Direction: Direction.Down);
                if (states.Any(x => x.Equals(hypothetical)))
                {
                    obstructed[position.x, position.y + 1] = true;
                }
                position.y++;
            }
            break;
        case Direction.Up:
            if (map[position.x - 1, position.y] == '#')
            {
                direction = Direction.Right;
            }
            else
            {
                var hypothetical = new State(X: position.x, Y: position.y, Direction: Direction.Right);
                if (states.Any(x => x.Equals(hypothetical)))
                {
                    obstructed[position.x - 1, position.y] = true;
                }
                position.x--;
            }
            break;
        default:
            throw new ArgumentOutOfRangeException
            {
                HelpLink = null,
                HResult = 0,
                Source = null
            };
    }
    states.Add(new State(X: position.x, Y: position.y, Direction: direction));
    //PrintMap(map);
}

var obstructedT = Transform.ConvertFrom2D(obstructed);
var obstructedC = obstructedT.Select(x => x.Count(y => y)).Sum();
Console.WriteLine($"Part2 : {obstructedC}");

return;

void PrintMap(char[,] map)
{
    var rows = map.GetLength(0);
    var cols = map.GetLength(1);

    for (var i = 0; i < rows; i++)
    {
        for (var j = 0; j < cols; j++)
        {
            Console.Write(map[i, j]);
        }

        Console.WriteLine();
    }
    Console.WriteLine("------------------------------");
}

enum Direction
{
    Up, Down, Left, Right
}

record struct State(Direction Direction, int Y, int X) {}