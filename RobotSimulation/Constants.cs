public static class Constants
{
    public struct Directions
    {
        public const string North = "NORTH";
        public const string South = "SOUTH";
        public const string East = "EAST";
        public const string West = "WEST";
    }

    public struct Commands
    {
        public const string Place = "PLACE";
        public const string Move = "MOVE";
        public const string Left = "LEFT";
        public const string Right = "RIGHT";
        public const string Report = "REPORT";
    }

    public struct Errors
    {
        public const string InvalidPosition = "Place: Invalid position.";
        public const string InvalidMove = "MOVE: Invalid move.";
        public const string PlaceIsNotSet = "Place: Missing place command.";
    }
}
