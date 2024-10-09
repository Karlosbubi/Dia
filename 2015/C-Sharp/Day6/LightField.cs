namespace Day6;

public class LightFieldPart1
{
    private readonly bool[,] _lights = new bool[1000,1000];

    public int On => _lights.Cast<bool>().Count(light => light);

    public void ProcessCommand(LightCommand command)
    {
        for (int i = command.From.x; i <= command.To.x; i++)
        {
            for (int j = command.From.y; j <= command.To.y; j++)
            {
                _lights[i, j] = command.Operation switch
                {
                    LightOperation.On => true,
                    LightOperation.Off => false,
                    LightOperation.Toggle => !_lights[i, j],
                    _ => _lights[i, j]
                };
            }
        }
    }
}

public class LightFieldPart2
{
    private readonly int[,] _lights = new int[1000,1000];
    
    public int Brightness => _lights.Cast<int>().Sum();

    public void ProcessCommand(LightCommand command)
    {
        for (int i = command.From.x; i <= command.To.x; i++)
        {
            for (int j = command.From.y; j <= command.To.y; j++)
            {
                switch (command.Operation)
                {
                    case LightOperation.On:
                        _lights[i, j] += 1;
                        break;
                    case LightOperation.Off:
                        if(_lights[i, j] > 0)
                            _lights[i, j] -= 1;
                        break;
                    case LightOperation.Toggle:
                        _lights[i, j] += 2;
                        break;
                }
            }
        }
    }
}