﻿// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using Utils;

Console.WriteLine("Hello, World!");

var input = LoadInput.AsText("Day3");
var part1 = Regex.Matches(input, @"mul\(\d+,\d+\)").Select(m =>
{
  var parts = m.Value.Replace("mul(", string.Empty).Replace(")", string.Empty).Split(',');
  return int.Parse(parts[0]) * int.Parse(parts[1]);
}).Sum();
Console.WriteLine($"Part1: {part1}");

var matches = Regex.Matches(input, @"mul\(\d+,\d+\)|do\(\)|don't\(\)").Select(m => m.Value).ToArray();
var doMul = true;
var part2 = matches.Select(m =>
{
  if (m.Equals("do()"))
  {
    doMul = true;
    return 0;
  }

  if (m.Equals("don't()"))
  {
    doMul = false;
    return 0;
  }

  if (doMul)
  {
    var parts = m.Replace("mul(", string.Empty).Replace(")", string.Empty).Split(',');
    return int.Parse(parts[0]) * int.Parse(parts[1]);
  }

  return 0;
}).Sum();

Console.WriteLine($"Part2: {part2}");

