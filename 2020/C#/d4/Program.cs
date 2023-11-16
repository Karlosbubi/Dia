using System.Text.RegularExpressions;

var year = 2020;
var day = 4;

var input = File.ReadAllText(args[0]);
var lines = input.Split('\n');

var entries = new List<String>();
foreach (var line in lines)
{
    entries.AddRange(line.Split(' '));
}
var passports = ParsePasports(entries);

var result1 = 0;
foreach (Passport passport in passports)
{
    // Validate
    if (passport.byr == null)
    {
        continue;
    }
    if (passport.iyr == null)
    {
        continue;
    }
    if (passport.eyr == null)
    {
        continue;
    }
    if (passport.hgt == null)
    {
        continue;
    }
    if (string.IsNullOrWhiteSpace(passport.hcl))
    {
        continue;
    }
    if (string.IsNullOrWhiteSpace(passport.ecl))
    {
        continue;
    }
    if (string.IsNullOrWhiteSpace(passport.pid))
    {
        continue;
    }

    result1++;
}

var result2 = 0;
foreach (Passport passport in passports)
{
    // Validate
    if (passport.byr == null)
    {
        //Console.WriteLine($"DEBUG : byr missing -> invaild ");
        continue;
    }
    if (!(passport.byr >= 1920 && passport.byr <= 2002))
    {
        //Console.WriteLine($"DEBUG : byr = {passport.byr} is invaid");
        continue;
    }
    if (passport.iyr == null)
    {
        //Console.WriteLine($"DEBUG : iyr missing -> invaild ");
        continue;
    }
    if (!(passport.iyr >= 2010 && passport.iyr <= 2020))
    {
        //Console.WriteLine($"DEBUG : iyr = {passport.iyr} is invaid");
        continue;
    }
    if (passport.eyr == null)
    {
        //Console.WriteLine($"DEBUG : eyr missing -> invaild ");
        continue;
    }
    if (!(passport.eyr >= 2020 && passport.eyr <= 2030))
    {
        //Console.WriteLine($"DEBUG : eyr = {passport.eyr} is invaid");
        continue;
    }
    if (passport.hgt == null)
    {
        //Console.WriteLine($"DEBUG : hgt missing -> invaild ");
        continue;
    }
    if (passport.hgt_m == null)
    {
        //Console.WriteLine($"DEBUG : hgt_m missing -> invaild ");
        continue;
    }
    if (passport.hgt_m == Meassure.Imperial && !(passport.hgt >= 59 && passport.hgt <= 76))
    {
        //Console.WriteLine($"DEBUG : hgt = {passport.hgt}in is invaid");
        continue;
    }
    if (passport.hgt_m == Meassure.Metric && !(passport.hgt >= 150 && passport.hgt <= 193))
    {
        //Console.WriteLine($"DEBUG : hgt = {passport.hgt}cm is invaid");
        continue;
    }
    if (string.IsNullOrWhiteSpace(passport.hcl))
    {
        //Console.WriteLine($"DEBUG : hcl missing -> invaild ");
        continue;
    }
    if (!Regex.Match(passport.hcl, "#[0-9a-f][0-9a-f][0-9a-f][0-9a-f][0-9a-f][0-9a-f]").Success)
    {
        //Console.WriteLine($"DEBUG : hcl = {passport.hcl} is invaid");
        continue;
    }
    if (string.IsNullOrWhiteSpace(passport.ecl))
    {
        //Console.WriteLine($"DEBUG : ecl missing -> invaild ");
        continue;
    }
    if (!Regex.Match(passport.ecl, "amb|blu|brn|gry|grn|hzl|oth").Success)
    {
        //Console.WriteLine($"DEBUG : ecl = {passport.ecl} is invaid");
        continue;
    }
    if (string.IsNullOrWhiteSpace(passport.pid))
    {
        //Console.WriteLine($"DEBUG : pid missing -> invaild ");
        continue;
    }
    if(!Regex.Match(passport.pid, "^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$").Success){
        //Console.WriteLine($"DEBUG : pid = {passport.pid} is invaid");
        continue;
    }

    result2++;
}

Console.WriteLine($"{year} Day {day}");
Console.WriteLine($"Task 1 : {result1}");
Console.WriteLine($"Task 2 : {result2}");

static IEnumerable<Passport> ParsePasports(IEnumerable<string> input)
{
    var Passports = new List<Passport>();

    Passport current = new Passport();

    foreach (var line in input)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            Passports.Insert(0, current);
            current = new Passport();
            continue;
        }

        //Console.WriteLine($"DEBUG : {line}");
        var tmp = line.Split(':');
        var key = tmp[0];
        var value = tmp[1];
        value = value.Trim();

        switch (key)
        {
            case "byr":
                current.byr = int.Parse(value);
                break;
            case "iyr":
                current.iyr = int.Parse(value);
                break;
            case "eyr":
                current.eyr = int.Parse(value);
                break;
            case "hgt":
                if (value.EndsWith("in"))
                {
                    current.hgt_m = Meassure.Imperial;
                    value = value[..^2];
                    //Console.WriteLine($"DEBUG : {value}");
                }
                if (value.EndsWith("cm"))
                {
                    current.hgt_m = Meassure.Metric;
                    value = value[..^2];
                    //Console.WriteLine($"DEBUG : {value}");
                }
                current.hgt = int.Parse(value);
                break;
            case "hcl":
                current.hcl = value;
                break;
            case "ecl":
                current.ecl = value;
                break;
            case "pid":
                current.pid = value;
                break;
            case "cid":
                current.cid = value;
                break;
        }

    }
    Passports.Insert(0, current);

    return Passports;
}

struct Passport
{
    public int? byr;
    public int? iyr;
    public int? eyr;
    public int? hgt;
    public Meassure? hgt_m;
    public String? hcl;
    public String? ecl;
    public String? pid;
    public String? cid;
}

enum Meassure
{
    Metric,
    Imperial
}