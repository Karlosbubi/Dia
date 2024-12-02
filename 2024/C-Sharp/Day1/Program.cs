// See https://aka.ms/new-console-template for more information

using Utils;

Console.WriteLine("Hello, World!");

var input = LoadInput.AsLines("Day1");

var (list1, list2) = input
    .Select(line => line
        .Split(' ')
        .Select(value => int.TryParse(value, out var num) ? (int?)num : null)
        .Where(num => num.HasValue)
        .Select(num => num.Value)
        .ToArray())
    .Where(nums => nums.Length == 2)
    .Aggregate((new List<int>(), new List<int>()), (acc, nums) =>
    {
        acc.Item1.Add(nums[0]);
        acc.Item2.Add(nums[1]);
        return acc;
    });

list1.Sort();
list2.Sort();

var diff = list1.Zip(list2, (x, y) => Math.Abs(x - y));
Console.WriteLine($"Day 1 Part 1: {diff.Sum()}");

var similarity = list1.Select(x => x * list2.Count(y => y == x));
Console.WriteLine($"Day 1 Part 2: {similarity.Sum()}");