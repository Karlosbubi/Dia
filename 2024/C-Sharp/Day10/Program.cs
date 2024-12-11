// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var input  = @"89010123
78121874
87430965
96549874
45678903
32019012
01329801
10456732"
    .Split('\n')
    .Where(s => !string.IsNullOrWhiteSpace(s))
    .Select(x=> x.Trim().ToCharArray()
        .Select(y => int.Parse(y.ToString()))
        .ToArray())
    .ToArray();


