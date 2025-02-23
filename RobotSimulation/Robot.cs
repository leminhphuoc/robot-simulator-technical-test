public class Robot
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public string Direction { get; private set; } = string.Empty;
    private readonly Table _table;
    public bool IsPlaced { get; private set; }

    public Robot(Table table)
    {
        _table = table;
    }

    public void Place(int x, int y, string direction)
    {
        if (!_table.IsValidPosition(x, y))
        {
            throw new InvalidOperationException(Constants.Errors.InvalidPosition);
        }

        X = x;
        Y = y;
        Direction = direction;
        IsPlaced = true;
    }

    public void Move()
    {
        if (!IsPlaced)
        {
            return;
        }

        int newX = X;
        int newY = Y;
        switch (Direction)
        {
            case Constants.Directions.North:
                newY++;
                break;
            case Constants.Directions.South:
                newY--;
                break;
            case Constants.Directions.East:
                newX++;
                break;
            case Constants.Directions.West:
                newX--;
                break;
        }
        if (!_table.IsValidPosition(newX, newY))
        {
            throw new InvalidOperationException(Constants.Errors.InvalidMove);
        }
        X = newX;
        Y = newY;
    }

    public void Left()
    {
        if (!IsPlaced)
        {
            return;
        }

        Direction = Direction switch
        {
            Constants.Directions.North => Constants.Directions.West,
            Constants.Directions.West => Constants.Directions.South,
            Constants.Directions.South => Constants.Directions.East,
            Constants.Directions.East => Constants.Directions.North,
            _ => Direction,
        };
    }

    public void Right()
    {
        if (!IsPlaced)
        {
            return;
        }

        Direction = Direction switch
        {
            Constants.Directions.North => Constants.Directions.East,
            Constants.Directions.East => Constants.Directions.South,
            Constants.Directions.South => Constants.Directions.West,
            Constants.Directions.West => Constants.Directions.North,
            _ => Direction,
        };
    }

    public string Report()
    {
        if (!IsPlaced)
        {
            throw new InvalidOperationException(Constants.Errors.PlaceIsNotSet);
        }

        return $"{X},{Y},{Direction}";
    }
}
