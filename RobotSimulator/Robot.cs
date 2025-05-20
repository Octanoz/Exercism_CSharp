namespace RobotSimulator;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class Robot(Direction direction, int x, int y)
{
    public Direction Direction { get; set; } = direction;
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

    public void Move(string instructions)
    {
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case 'A':
                    Advance(Direction);
                    break;
                case 'L':
                    Direction = (Direction)(((int)Direction + 3) % 4);
                    break;
                case 'R':
                    Direction = (Direction)(((int)Direction + 1) % 4);
                    break;
            }
        }

        Console.WriteLine($"Robot direction: {Direction} - [X: {X}, Y: {Y}]");
    }

    private void Advance(Direction direction) => (X, Y) = direction switch
    {
        Direction.North => (X, ++Y),
        Direction.East => (++X, Y),
        Direction.South => (X, --Y),
        Direction.West => (--X, Y),
        _ => throw new ArgumentException($"Invalid direction: {direction}")
    };
}