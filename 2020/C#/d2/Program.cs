var input = File.ReadAllText("../../Inputs/2020/Day2.txt");
var lines = input.Split('\n');

var result1 = 0; // Valid Counter
foreach(var line in lines){
    int min, max;
    char letter;

    var segments = line.Split(' ');

    var nums = segments[0].Split('-');
    min = int.Parse(nums[0]);
    max = int.Parse(nums[1]);

    letter = segments[1].ToCharArray()[0];

    var count = segments[2].ToCharArray().Count(c => c == letter);

    if(count >= min && count <= max){
        result1++;
    }
}

var result2 = 0; // Valid Counter
foreach(var line in lines){
    int pos1, pos2;
    char letter;

    var segments = line.Split(' ');

    var nums = segments[0].Split('-');
    pos1 = int.Parse(nums[0]) - 1;
    pos2 = int.Parse(nums[1]) - 1;

    letter = segments[1].ToCharArray()[0];
    var char_line = segments[2].ToCharArray();

    if((char_line[pos1] == letter && char_line[pos2] != letter)
    || (char_line[pos1] != letter && char_line[pos2] == letter)){
        result2++;
        //Console.WriteLine($"DEBUG : {line} is valid | {char_line[pos1]} | {char_line[pos2]}");
    }
    else{
        //Console.WriteLine($"DEBUG : {line} is NOT valid | {char_line[pos1]} | {char_line[pos2]}");
    }
}

Console.WriteLine("2020 Day 2");
Console.WriteLine($"Task 1 : {result1}");
Console.WriteLine($"Task 2 : {result2}");
