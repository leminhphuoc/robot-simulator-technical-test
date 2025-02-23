using System;
using System.IO;
using System.Linq;
using Xunit;
using static Constants;

public class RobotTests
{
    [Theory]
    [InlineData("PLACE 0,0,NORTH\nMOVE\nREPORT", "0,1,NORTH")]
    [InlineData("PLACE 0,0,NORTH\nLEFT\nREPORT", "0,0,WEST")]
    [InlineData("PLACE 1,2,EAST\nMOVE\nMOVE\nLEFT\nMOVE\nREPORT", "3,3,NORTH")]
    [InlineData("PLACE 4,4,EAST\nMOVE\nREPORT", "4,4,EAST")]
    [InlineData("PLACE 0,0,SOUTH\nMOVE\nREPORT", "0,0,SOUTH")]
    [InlineData("PLACE 0,0,WEST\nMOVE\nREPORT", "0,0,WEST")]
    [InlineData("PLACE 4,4,NORTH\nMOVE\nREPORT", "4,4,NORTH")]
    [InlineData("PLACE 4,4,WEST\nMOVE\nREPORT", "3,4,WEST")]
    [InlineData("PLACE 2,2,SOUTH\nRIGHT\nRIGHT\nMOVE\nREPORT", "2,3,NORTH")]
    [InlineData("PLACE 3,3,EAST\nLEFT\nMOVE\nLEFT\nMOVE\nREPORT", "2,4,WEST")]
    public void TestRobotMovement(string input, string expectedOutput)
    {
        Table table = new Table(5, 5);
        var robot = new Robot(table);
        var commandProcessor = new CommandProcessor(robot);

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            foreach (string command in input.Split('\n'))
            {
                commandProcessor.ProcessCommand(command.Trim());
            }

            string output = sw.ToString().Trim();
            Assert.Contains(expectedOutput, output);
        }
    }

    [Theory]
    [InlineData("PLACE -1,-1,NORTH\nREPORT", "")]
    [InlineData("PLACE 5,5,EAST\nREPORT", "")]
    [InlineData("MOVE\nLEFT\nREPORT", "")]
    public void TestInvalidCommands(string input, string expectedOutput)
    {
        Table table = new Table(5, 5);
        var robot = new Robot(table);
        var commandProcessor = new CommandProcessor(robot);

        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);

            foreach (string command in input.Split('\n'))
            {
                commandProcessor.ProcessCommand(command.Trim());
            }

            string output = sw.ToString().Trim();
            Assert.Equal(expectedOutput, output);
        }
    }
}