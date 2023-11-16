var input = File.ReadAllText("../../../Inputs/2020/Day1.txt");
var lines = input.Split('\n');
var vals = from l in lines select int.Parse(l);

var result1 =   from v1 in vals
                from v2 in vals
                where (v1 + v2) == 2020
                select (v1 * v2);

var result2 =   from v1 in vals
                from v2 in vals
                from v3 in vals
                where (v1 + v2 + v3) == 2020
                select (v1 * v2 * v3);

Console.WriteLine("2020 Day 1");
Console.WriteLine($"Task 1 : {result1.FirstOrDefault(0)}");
Console.WriteLine($"Task 2 : {result2.FirstOrDefault(0)}");
