var year = 0;
var day = 0;

// dotnet run -- ../../../Inputs/YEAR/DayX.txt
var input = File.ReadAllText(args[0]);
var lines = input.Split('\n').ToArray();

var result1 = 0;
var result2 = 0;

Console.WriteLine($"{year} Day {day}");
Console.WriteLine($"Task 1 : {result1}");
Console.WriteLine($"Task 2 : {result2}");