// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using Utils;

Console.WriteLine("Hello, World!");

var input = LoadInput.AsLines("Day4").ToArray();

var sum = 0;
var array = Transform.ConvertTo2D(input.Select(x => x.ToCharArray()).ToArray());

for (var i = 0; i < array.GetLength(0); i++)
{
    for (var j = 0; j < array.GetLength(1); j++)
    {
        // Forwards
        if (array[i, j] == 'X')
        {
            if (i < array.GetLength(0) - 3)
            {
                // Horizontal
                if (array[i + 1, j] == 'M')
                {
                    if (array[i + 2, j] == 'A' && array[i + 3, j] == 'S')
                    {
                        sum++;
                    }
                }
            }


            if (j < array.GetLength(1) - 3)
            {
                // Vertical
                if (array[i, j + 1] == 'M')
                {
                    if (array[i, j + 2] == 'A' && array[i, j + 3] == 'S')
                    {
                        sum++;
                    }
                }
            }

            if (i < array.GetLength(0) - 3 && j < array.GetLength(1) - 3)
            {
                // Diagonal
                if (array[i + 1, j + 1] == 'M')
                {
                    if (array[i + 2, j + 2] == 'A' && array[i + 3, j + 3] == 'S')
                    {
                        sum++;
                    }
                }
            }
        }

        // Backwards

        if (array[i, j] == 'S')
        {
            if (i < array.GetLength(0) - 3)
            {
                // Horizontal
                if (array[i + 1, j] == 'A')
                {
                    if (array[i + 2, j] == 'M' && array[i + 3, j] == 'X')
                    {
                        sum++;
                    }
                }
            }

            if (j < array.GetLength(1) - 3)
            {
                // Vertical
                if (array[i, j + 1] == 'A')
                {
                    if (array[i, j + 2] == 'M' && array[i, j + 3] == 'X')
                    {
                        sum++;
                    }
                }
            }

            if (i < array.GetLength(0) - 3 && j < array.GetLength(1) - 3)
            {
                // Diagonal
                if (array[i + 1, j + 1] == 'A')
                {
                    if (array[i + 2, j + 2] == 'M' && array[i + 3, j + 3] == 'X')
                    {
                        sum++;
                    }
                }
            }
        }

        // Right leaning Diagonals
        if (j >= 3 && i < array.GetLength(0) - 3)
        {
            // Forwards
            if (array[i, j] == 'X')
            {
                if (array[i + 1, j - 1] == 'M' && array[i + 2, j - 2] == 'A' && array[i + 3, j - 3] == 'S')
                {
                    sum++;
                }
            }

            // Backwards
            if (array[i, j] == 'S')
            {
                if (array[i + 1, j - 1] == 'A' && array[i + 2, j - 2] == 'M' && array[i + 3, j - 3] == 'X')
                {
                    sum++;
                }
            }
        }
    }
}

Console.WriteLine($"Part1: {sum}");

var sum2 = 0;
for (var i = 1; i < array.GetLength(0) - 1; i++)
{
    for (var j = 1; j < array.GetLength(1) - 1; j++)
    {
        if (array[i, j] == 'A')
        {
            //S S
            // A
            //M M
            if (array[i + 1, j - 1] == 'M' && 
                array[i + 1, j + 1] == 'M' && 
                array[i - 1, j - 1] == 'S' && 
                array[i - 1, j + 1] == 'S')
            {
                sum2++;
            }
            //M M
            // A
            //S S
            if (array[i - 1, j - 1] == 'M' && 
                array[i - 1, j + 1] == 'M' && 
                array[i + 1, j - 1] == 'S' && 
                array[i + 1, j + 1] == 'S')
            {
                sum2++;
            }
            //M S
            // A
            //M S
            if (array[i - 1, j - 1] == 'M' && 
                array[i + 1, j - 1] == 'M' && 
                array[i - 1, j + 1] == 'S' && 
                array[i + 1, j + 1] == 'S')
            {
                sum2++;
            }
            //S M
            // A
            //S M
            if (array[i - 1, j + 1] == 'M' && 
                array[i + 1, j + 1] == 'M' && 
                array[i - 1, j - 1] == 'S' && 
                array[i + 1, j - 1] == 'S')
            {
                sum2++;
            }
        }
    }
}

Console.WriteLine($"Part2: {sum2}");

