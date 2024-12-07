// See https://aka.ms/new-console-template for more information

using System.Data;
using Utils;

Console.WriteLine("Hello, World!");

bool test = false;
bool debug = false;

var input = @"
190: 10 19
3267: 81 40 27
83: 17 5
156: 15 6
7290: 6 8 6 15
161011: 16 10 13
192: 17 8 14
21037: 9 7 18 13
292: 11 6 16 20".Split('\n');

if (!test)
{
    input = LoadInput.AsLines("Day7").ToArray();
}

if (debug)
{
    Console.WriteLine($"Input lines : {input.Length}");
}

var calibrations = input.Where(s=> !string.IsNullOrWhiteSpace(s)).Select(s => new Calibration(s, debug || test)).ToArray();

var part1 = calibrations.Select(c => c.Part1()).Sum();
Console.WriteLine($"Part 1: {part1}");
var part2 = calibrations.Select(c => c.Part2()).Sum();
Console.WriteLine($"Part 2: {part2}");

class Calibration
{
    private readonly long _value;
    private readonly List<int> _parts;
    private readonly IEnumerable<Operation[]> _part1Permutations;
    private readonly IEnumerable<Operation[]> _part2Permutations;

    private readonly bool _debug;

    public Calibration(string input, bool debug = false)
    {
        ArgumentNullException.ThrowIfNull(input);
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input));
        }
        var split = input.Split(':');
        _value = long.Parse(split[0]);
        _parts = [..split[1].Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(int.Parse)];
        _part1Permutations = GeneratePart1Permutations();
        _part2Permutations = GeneratePart2Permutations();
        _debug = debug;
    }

    private IEnumerable<Operation[]> GeneratePart1Permutations()
    {
        var counter = 0;
        var opsCount = _parts.Count - 1;
        var permCount =  Math.Pow(2, opsCount);

        if (_debug)
        {
            Console.WriteLine($"ops count : {opsCount}, permutation count: {permCount}");
        }
        

        while (counter < permCount)
        {
            var currentPermutation = Convert.ToString(counter, 2).PadLeft(opsCount, '0').ToCharArray().Select(c =>
            {
                return c switch
                {
                    '0' => Operation.Add,
                    '1' => Operation.Multiply,
                    _ => throw new InvalidOperationException()
                };
            }).ToArray();
            yield return currentPermutation;
            counter++;
        }
    }
    
    private IEnumerable<Operation[]> GeneratePart2Permutations()
    {
        var counter = 0;
        var opsCount = _parts.Count - 1;
        var permCount =  Math.Pow(3, opsCount);

        if (_debug)
        {
            Console.WriteLine($"ops count : {opsCount}, permutation count: {permCount}");
        }
        

        while (counter < permCount)
        {
            var currentPermutation = Other.DecimalToArbitrarySystem(counter, 3).PadLeft(opsCount, '0').ToCharArray().Select(c =>
            {
                return c switch
                {
                    '0' => Operation.Add,
                    '1' => Operation.Multiply,
                    '2' => Operation.Concat,
                    _ => throw new InvalidOperationException()
                };
            }).ToArray();
            yield return currentPermutation;
            counter++;
        }
    }

    private (bool valid, long value) EvaluatePart1Permutation(IEnumerable<Operation> permutation)
    {
        var operations = permutation as Operation[] ?? permutation.ToArray();

        long value = _parts[0];
        for (var i = 0; i < operations.Length; i++)
        {
            switch (operations[i])
            {
                case Operation.Add :
                    value += _parts[i + 1];
                    break;
               case Operation.Multiply :
                    value *= _parts[i + 1];
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            };
        }
        var valid = value == _value;

        if (_debug)
        {
            Console.WriteLine($"{Part1PermutationToString(operations)} = {value}" + (valid ? $" == {_value}" : $" != {_value}"));
        }
        return (valid, value);
    }
    
    private (bool valid, long value) EvaluatePart2Permutation(IEnumerable<Operation> permutation)
    {
        var operations = permutation as Operation[] ?? permutation.ToArray();

        long value = _parts[0];
        for (var i = 0; i < operations.Length; i++)
        {
            switch (operations[i])
            {
                case Operation.Add :
                    value += _parts[i + 1];
                    break;
                case Operation.Multiply :
                    value *= _parts[i + 1];
                    break;
                case Operation.Concat:
                    value = long.Parse($"{value}{_parts[i + 1]}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            };
        }
        var valid = value == _value;

        if (_debug)
        {
            Console.WriteLine($"{Part1PermutationToString(operations)} = {value}" + (valid ? $" == {_value}" : $" != {_value}"));
        }
        return (valid, value);
    }

    private string Part1PermutationToString(IEnumerable<Operation> permutation)
    {
        var ops = permutation.Select(o =>
        {
            return o switch
            {
                Operation.Add => "+",
                Operation.Multiply => "*",
                Operation.Concat => "||",
                _ => throw new InvalidOperationException()
            };
        });
        return string.Join(' ', _parts.Zip(ops, (s, o) => $"{s} {o}")) + $" {_parts.Last()}";
    }
    
    public long Part1() => _part1Permutations.Select(EvaluatePart1Permutation).Any(x => x.valid) ? _value : 0;
    public long Part2() => _part2Permutations.Select(EvaluatePart2Permutation).Any(x => x.valid) ? _value : 0;
}

enum Operation
{
    Multiply,
    Add,
    Concat,
}