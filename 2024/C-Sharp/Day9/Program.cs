// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var input = "2333133121414131402".ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

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
            block.State = DiskState.File;
        }
        else
        {
            block.Id = -1;
            block.State = DiskState.Empty;
        }
        blocks.Add(block);
    }
    fileId++;
    file = !file;
}

blocks = Defragment(blocks).ToList();

foreach (var block in blocks)    
{   
    Console.WriteLine(block);
}

IEnumerable<Block> Defragment(IEnumerable<Block> blocks)
{
    var _blocks = blocks as Block[] ?? blocks.ToArray();

    for (int i = 0; i < _blocks.Length; i++)
    {
        if (_blocks[i].State == DiskState.File)
        {
            yield return _blocks[i];
        }
        else
        {
            for (int j = _blocks.Length - 1; j > 0; j--)
            {
                if (_blocks[j].State == DiskState.File)
                {
                    yield return _blocks[j];
                    break;
                }
            }
        }
    }
}

record struct Block
{
    public int Id;
    public DiskState State;
}

enum DiskState
{
    Empty,
    File
}