namespace Utils;

public static class Transform
{
    public static T[,] Transpose<T>(T[,] input)
    {
        var rows = input.GetLength(0);
        var cols = input.GetLength(1);
        var result = new T[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[j, i] = input[i, j];
            }
        }

        return result;
    }

    public static T[][] Transpose<T>(T[][] input)
    {
        return ConvertFrom2D(Transpose(ConvertTo2D(input)));
    }
    
    public static T[,] ConvertTo2D<T>(T[][] jaggedArray)
    {
        // Get dimensions
        var rows = jaggedArray.Length;
        var cols = jaggedArray.Select(x => x.Length).Max();

        // Create new 2D array
        var result = new T[rows, cols];

        // Copy elements
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (j < jaggedArray[i].Length)
                {
                    result[i, j] = jaggedArray[i][j];
                }
            }
        }

        return result;
    }
    
    public static T[][] ConvertFrom2D<T>(T[,] array)
    {
        // Get dimensions
        var rows = array.GetLength(0);
        var cols = array.GetLength(1);

        // Create new 2D array
        var result = new T[rows][];
        for (var i = 0; i < rows; i++)
        {
            result[i] = new T[cols];
        }

        // Copy elements
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                result[i][j] = array[i, j];
            }
        }

        return result;
    }
    
    public static T[] GetDiagonal<T>(T[,] array, int startRow, int startCol)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        List<T> diagonal = new List<T>();

        int row = startRow;
        int col = startCol;

        while (row < rows && col < cols)
        {
            diagonal.Add(array[row, col]);
            row++;
            col++;
        }

        return diagonal.ToArray();
    }
    
    public static T[] GetBackwardsDiagonal<T>(T[,] array, int startRow, int startCol)
    {
        var diagonal = new List<T>();

        var row = startRow;
        var col = startCol;

        while (row >= 0 && col < array.GetLength(1))
        {
            diagonal.Add(array[row, col]);
            row--;
            col++;
        }
        
        row = startRow;
        col = startCol;

        while (row < array.GetLength(0) && col >= 0)
        {
            diagonal.Add(array[row, col]);
            row++;
            col--;
        }

        return diagonal.ToArray();
    }
}