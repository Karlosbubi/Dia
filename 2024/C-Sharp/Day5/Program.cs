// See https://aka.ms/new-console-template for more information

using Utils;

Console.WriteLine("Hello, World!");

var input = LoadInput.AsLines("Day5");

var ordersStrings = new List<string>();
var updatesStrings = new List<string>();
var junction = false;
foreach (var line in input)
{
    if (line == String.Empty)
    {
        junction = true;
        continue;
    }

    if (junction)
    {
        updatesStrings.Add(line);
    }
    else
    {
        ordersStrings.Add(line);
    }
}

var orders = ordersStrings.Select(s =>
{
    var order = s.Split('|').Select(int.Parse).ToArray();
    return new { X = order[0], Y = order[1] };
}).ToArray();
var updates = updatesStrings.Select(s => s.Split(',').Select(int.Parse).ToArray()).ToArray();


var part1 = updates.Select(CheckUpdate).Sum();
Console.WriteLine($"Part 1: {part1}");

var part2 = updates.Where(x => CheckUpdate(x) == 0).Select(FixUpdate).Select(CheckUpdate).Sum();
Console.WriteLine($"Part 2: {part2}");
return;

// Caution Requires "orders" from outer scope
int CheckUpdate(int[] update)
{
    bool correct = true;
    foreach (var order in orders)
    {
        if (update.Contains(order.X) && update.Contains(order.Y))
        {
            var x = Array.FindIndex(update, x => x == order.X);
            var y = Array.FindIndex(update, y => y == order.Y);
            correct &= x < y;
        }
    }
    //Console.WriteLine($"\"{string.Join(",", update)}\"  Middle {update[update.Length / 2]}");
    return correct ? update[update.Length / 2] : 0;
}

// Caution Requires "orders" from outer scope
int[] FixUpdate(int[] update)
{
    while (CheckUpdate(update) == 0)
    {
        foreach (var order in orders)
        {
            if (!update.Contains(order.X) || !update.Contains(order.Y)) continue;
            var x = Array.FindIndex(update, x => x == order.X);
            var y = Array.FindIndex(update, y => y == order.Y);
            if (x < y) continue;
            update[y] = order.X;
            update[x] = order.Y;
        }
    }
    return update;
}