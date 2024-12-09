using System.Linq.Expressions;

namespace Utils;

public class Homography
{
    public static (double x, double y) ApplyHomography(double[,] matrix, (double x, double y) point)
    {
        var (x, y) = point;
        var transformed = new[]
        {
            matrix[0, 0] * x + matrix[0, 1] * y + matrix[0, 2],
            matrix[1, 0] * x + matrix[1, 1] * y + matrix[1, 2],
            matrix[2, 0] * x + matrix[2, 1] * y + matrix[2, 2]
        };
        return (
            transformed[0] / transformed[2],
            transformed[1] / transformed[2]
        );
    }

    public static Func<(double x, double y), (double x, double y)> MakeTransformer(double[,] matrix)
    {
        return p => ApplyHomography(matrix, (p.x, p.y));
    }

    public static void Main(string[] args)
    {
        (double x, double y)[] points =  [(1,3), (2,3), (3,3), (4, 2), (6, 9)];
        
        double[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        
        var transform = MakeTransformer(matrix);
        
        var newPoints = points.Select( x => transform(x));
        
        Console.WriteLine(string.Join(',', newPoints));
    }
}