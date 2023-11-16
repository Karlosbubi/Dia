var year = 2020;
var day = 3;

var input = File.ReadAllText(args[0]);
var lines = (from l in input.Split('\n') select l.ToCharArray()).ToArray();

var result1 = CheckSlope(3, 1, lines);



decimal result2 = CheckSlope(1, 1, lines);
result2 *= CheckSlope(3, 1, lines);
result2 *= CheckSlope(5, 1, lines);
result2 *= CheckSlope(7, 1, lines);
result2 *= CheckSlope(1, 2, lines);


//DebugPrintTerrain(lines);

Console.WriteLine($"{year} Day {day}");
Console.WriteLine($"Task 1 : {result1}");
Console.WriteLine($"Task 2 : {result2}");

static int CheckSlope(int delta_x, int delta_y, char[][] terrain){
    var result = 0;
    int len = terrain.Length - 1;
    int width = terrain[0].Length - 1;
    int x = 0;
    for (int y = 0; y < len; y += delta_y){
        if(terrain[y][x] == '#' || terrain[y][x] == 'x'){
            result++;
            terrain[y][x] = 'x';
        }
        else{
            terrain[y][x] = 'o';
        }

        //Console.WriteLine($"DEBUG : X = {x}; y = {y}; char = {terrain[y][x]}; counter = {result}");

        x += delta_x;
        x = x % width;
    }

    return result;
}

#pragma warning disable CS8321
static void DebugPrintTerrain(char[][] terrain) {
    foreach(var line in terrain){
        Console.WriteLine(line);
    }
}