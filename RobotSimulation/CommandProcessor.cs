using static Constants;

public class CommandProcessor
{
    private readonly Robot _robot;

    public CommandProcessor(Robot robot)
    {
        _robot = robot;
    }

    public void ProcessCommand(string command)
    {
        try
        {
            var parts = command.Split(' ');
            var action = parts[0];

            switch (action)
            {
                case Commands.Place:
                    if (parts.Length <= 1)
                    {
                        Console.WriteLine("PLACE: Invalid parameters.");
                        return;
                    }

                    var parameters = parts[1].Split(',');
                    if (
                        parameters.Length == 3
                        && int.TryParse(parameters[0], out int x)
                        && int.TryParse(parameters[1], out int y)
                    )
                    {
                        _robot.Place(x, y, parameters[2]);
                    }
                    break;
                case Commands.Move:
                    _robot.Move();
                    break;
                case Commands.Left:
                    _robot.Left();
                    break;
                case Commands.Right:
                    _robot.Right();
                    break;
                case Commands.Report:
                    Console.WriteLine(_robot.Report());
                    break;
            }
        }
        catch(Exception)
        {
            Console.WriteLine("");
        }
        
    }
}
