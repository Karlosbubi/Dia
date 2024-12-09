// See https://aka.ms/new-console-template for more information

using Utils;

Console.WriteLine("Hello, World!");

var debug = false;
var test = false;

var input = "2333133121414131402".ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
if (!test)
{
    input = LoadInput.AsText("Day9").Trim().ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
}

var file = true;
var fileId = 0;
var blocks = new List<Block>();
foreach (var x in input)
{
    for (var j = 0; j < x; j++)
    {
        var block = new Block();
        if (file)
        {
            block.Id = fileId;
            block.Size = x;
            block.State = DiskState.File;
        }
        else
        {
            block.Id = -fileId;
            block.Size = x;
            block.State = DiskState.Empty;
        }
        blocks.Add(block);
    }

    if (file)
    {
        fileId++;
    }
    file = !file;
}

if (debug)
{
    Console.WriteLine($"Parsed Blocks");
    Console.WriteLine(String.Join("", blocks.Select(x => x.State == DiskState.Empty ? "." : x.Id.ToString())));
}

var blocks1 = DefragmentPart1(blocks).ToList();
if (debug)
{
    Console.WriteLine($"Defragmented Part1");
    Console.WriteLine(String.Join("", blocks1.Select(x => x.State == DiskState.Empty ? "." : x.Id.ToString())));
}
var part1 = blocks1.Where(x => x.State == DiskState.File).Select((x, i) => (long) x.Id * i).Sum();
Console.WriteLine($"Part 1: {part1}");

var blocks2 = DefragmentPart2(blocks).ToList();
if (debug)
{
    Console.WriteLine($"Defragmented Part2");
    Console.WriteLine(String.Join("", blocks2.Select(x => x.State == DiskState.Empty ? "." : x.Id.ToString())));
}
var part2 = blocks2.Select((x, i) => (x.State == DiskState.File ? (long) x.Id * i : 0)).Sum();
Console.WriteLine($"Part 2: {part2}");

return;

IEnumerable<Block> DefragmentPart1(IEnumerable<Block> diskBlocks)
{
    var array = diskBlocks as Block[] ?? diskBlocks.ToArray();
    var returnCounter = 0;

    for (var i = 0; i < array.Length; i++)
    {
        if (array[i].State == DiskState.File)
        {
            returnCounter++;
            yield return array[i];
        }
        else
        {
            for (var j = array.Length - 1; j > i; j--)
            {
                if (array[j].State != DiskState.File) continue;
                returnCounter++;
                yield return array[j];
                array[j].State = DiskState.Empty;
                break;
            }
        }
    }

    while (returnCounter < array.Length)
    {
        yield return new Block
        {
            Id = -1,
            State = DiskState.Empty,
        };
        returnCounter++;
    }
}

IEnumerable<Block> DefragmentPart2(IEnumerable<Block> diskBlocks)
{
    var array = diskBlocks.Distinct().ToList();
    var fill = array.Where(x => x.State == DiskState.File).OrderBy(x => x.Id).Reverse().ToList();
    var newBlocks = new List<Block>();

    for (var i = 0; i < array.Count; i++)
    {
        if (array[i].State == DiskState.File)
        {
            if (debug)
            {
                Console.WriteLine($"File {array[i].Id}, size {array[i].Size}");
            }
            newBlocks.Add(array[i]);
            fill.Remove(array[i]);
        }
        else
        {
            var s = array[i].Size;
            if (debug)
            {
                Console.WriteLine($"Empty space: {s}");
            }
            while (fill.Any(x => x.Size <= s))
            {
                var b = fill.First(x => x.Size <= s);
                newBlocks.Add(b);
                fill.Remove(b);
                var bi = array.IndexOf(b);
                array.Remove(b);
                array.Insert(bi, new Block{State = DiskState.Empty, Size = b.Size, Id = -1});
                s -= b.Size;
                if (debug)
                { 
                    Console.WriteLine($"Filled with: {b}");
                }
            }

            newBlocks.Add(new Block { Id = -1, Size = s, State = DiskState.Empty });
        }
    }
    
    foreach (var block in newBlocks)
    {
        for (var i = 0; i < block.Size; i++)
        {
            yield return block;
        }
    }
}

record struct Block
{
    public int Id;
    public int Size;
    public DiskState State;
}

enum DiskState
{
    Empty,
    File
}