# Robots Technical Test

## Introduction
This project is a technical test for managing robots. It includes functionalities for creating, updating, and deleting robots.

## Prerequisites
- .NET 9.0 SDK

## Running the Project
1. Navigate to the project folder and restore libraries:
    ```sh
    cd RobotSimulation
    ```
2. Modify the `.\RobotSimulation\commands.txt` file with supported commands:
   1. PLACE X,Y,F: 
      1. This command places the robot on the table at the specified coordinates (X, Y) and facing the specified direction F (which can be NORTH, SOUTH, EAST, or WEST).
      2. This is the initial command that must be executed before any other commands are considered valid.
      3. Example: PLACE 1,2,NORTH places the robot at coordinates (1, 2) facing NORTH.
   2. MOVE:
      1. This command moves the robot one unit forward in the direction it is currently facing.
      2. The robot will not move if the move would cause it to fall off the table.
      3. Example: If the robot is at (1, 2) facing NORTH, a MOVE command will move it to (1, 3).
   3. LEFT:
      1. This command rotates the robot 90 degrees to the left (counter-clockwise) without changing its position.
      2. Example: If the robot is facing NORTH, a LEFT command will change its direction to WEST.
   4. RIGHT:
      1. This command rotates the robot 90 degrees to the right (clockwise) without changing its position.
      2. Example: If the robot is facing NORTH, a RIGHT command will change its direction to EAST.
   5. REPORT:
      1. This command outputs the current position and direction of the robot.
      2. Example: If the robot is at (1, 3) facing NORTH, a REPORT command will output 1,3,NORTH. 
3. Run the project:
    ```sh
    cd RobotSimulation
    dotnet run --file="commands.txt" --table-size="5,5"
    ```    
   1. The parameter `file` is the path of the commands file.
   2. The parameter `table-size` is the size of the table.

## Running Tests
To run the tests, use the following command:
```sh
cd RobotSimulation.Tests
dotnet test
```
