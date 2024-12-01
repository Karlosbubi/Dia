// See https://aka.ms/new-console-template for more information

using Utils;

Console.WriteLine("Hello, World!");

var input = LoadInput.AsLines("Day1");

var list1 = new List<int>();
var list2 = new List<int>();

input.ToList().ForEach(line=>
{
    var parts = line.Split(' ');
    if (parts.Length >= 2)
    {
        list1.Add(int.Parse(parts.First()));
        list2.Add(int.Parse(parts.Last()));
    }
});

list1.Sort();
list2.Sort();

var diff = list1.Zip(list2, (x, y) => Math.Abs(x - y));

Console.WriteLine($"Day 1 Part 1: {diff.Sum()}");

var similarity = list1.Select(x => x * list2.Count(y => y == x));
Console.WriteLine($"Day 1 Part 2: {similarity.Sum()}"); 