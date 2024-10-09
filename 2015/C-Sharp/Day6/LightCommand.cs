using System.Numerics;

namespace Day6;

public class LightCommand
{
    public LightOperation Operation { get; private set; }
    public (int x, int y) From { get; private set; }
    public (int x, int y)  To { get; private set; }

    public LightCommand(string s)
    {
        string[] split = s.Split(" ");
        if (split.Length == 4)
        {
            Operation = LightOperation.Toggle;
            var fromString = split[1];
            var toString = split[3];
            
            var fromSplit = fromString.Split(',');
            var toSplit = toString.Split(',');
            
            var fromX = int.Parse(fromSplit[0]);
            var fromY = int.Parse(fromSplit[1]);
            
            var toX = int.Parse(toSplit[0]);
            var toY = int.Parse(toSplit[1]);
            
            From = (fromX, fromY);
            To = (toX, toY);
            
            return;
        }

        if (split.Length == 5)
        {
            if (split[1] == "on")
                Operation = LightOperation.On;
            else if (split[1] == "off")
                Operation = LightOperation.Off;
            else
            {
                throw new FormatException($"Invalid command \"{s}\"");
            }
            
            var fromString = split[2];
            var toString = split[4];
            
            var fromSplit = fromString.Split(',');
            var toSplit = toString.Split(',');
            
            var fromX = int.Parse(fromSplit[0]);
            var fromY = int.Parse(fromSplit[1]);
            
            var toX = int.Parse(toSplit[0]);
            var toY = int.Parse(toSplit[1]);
            
            From = (fromX, fromY);
            To = (toX, toY);
            return;
        }
        
        throw new FormatException($"Invalid command \"{s}\"");
    }
    
    public LightCommand(LightOperation operation, (int, int) from, (int, int) to)
    {
        this.Operation = operation;
        this.From = from;
        this.To = to;
    }
}