// See https://aka.ms/new-console-template for more information

using Utils;

Console.WriteLine("Hello, World!");

var lines = LoadInput.AsLines("Day2");
var reports = lines.Select(line => line.Split(' ').Select(int.Parse).ToArray()).ToArray();
var saveP1 = reports.Select(IsReportSave);
var saveP2 = reports.Select(report =>
    report
        .Select((_, index) => report.Where((_, i) => i != index))
        .Select(IsReportSave).Any(save => save)
);

Console.WriteLine($"Save reports (Part1) : {saveP1.Count(s => s)}");
Console.WriteLine($"Save reports (Part2) : {saveP2.Count(s => s)}");

return;

bool IsReportSave(IEnumerable<int> report)
{
    var values = report as int[] ?? report.ToArray();
    var deltas = values.Zip(values.Skip(1), (a, b) => a - b)
        .ToArray();
    
    if (deltas.Any(x => Math.Abs(x) > 3))
    {
        return false;
    }

    if (deltas.Any(x => x == 0))
    {
        return false;
    }

    return deltas.Any(x => x < 0)
           ^ deltas.Any(x => x > 0);
}