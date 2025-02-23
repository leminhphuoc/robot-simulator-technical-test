using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = null;
        int tableWidth = 0;
        int tableHeight = 0;

        foreach (var arg in args)
        {
            if (arg.StartsWith("--file="))
            {
                filePath = arg.Substring("--file=".Length).Trim('"');
            }
            else if (arg.StartsWith("--table-size="))
            {
                var sizes = arg.Substring("--table-size=".Length).Trim('"').Split(',');
                if (
                    sizes.Length == 2
                    && int.TryParse(sizes[0], out tableWidth)
                    && int.TryParse(sizes[1], out tableHeight)
                )
                {
                    if (tableWidth <= 0 || tableHeight <= 0)
                    {
                        Console.WriteLine("Please provide valid dimensions for the table.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Please provide valid dimensions for the table.");
                    return;
                }
            }
        }

        if (filePath == null || tableWidth == 0 || tableHeight == 0)
        {
            Console.WriteLine(
                "Please provide the path to the commands file and the size of the table."
            );
            return;
        }

        Table table = new Table(tableWidth, tableHeight);
        var robot = new Robot(table);
        var commandProcessor = new CommandProcessor(robot);

        var commands = File.ReadAllLines(filePath);
        foreach (var command in commands)
        {
            commandProcessor.ProcessCommand(command);
        }
    }
}
