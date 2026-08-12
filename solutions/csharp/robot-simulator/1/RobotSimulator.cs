public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator(Direction direction, int x, int y)
{
    public Direction Direction { get; private set; } = direction;

    public int X { get; private set; } = x;


    public int Y { get; private set; } = y;


    public void Move(string instructions)
    {
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'A':
                    GoForward();
                    break;
            }
        }
    }

    private void TurnRight() => Direction = (Direction)((int)(Direction + 1) % 4);

    private void TurnLeft() => Direction = (Direction)((int)(Direction + 3) % 4);

    private void GoForward()
    {
        switch (Direction)
        {
            case Direction.North:
                Y += 1;
                break;
            case Direction.East:
                X += 1;
                break;
            case Direction.South:
                Y -= 1;
                break;
            case Direction.West:
                X -= 1;
                break;
        }
    }
}