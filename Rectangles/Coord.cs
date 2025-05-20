namespace Rectangles;

public record struct Coord(int Row, int Col)
{
    public static Coord Zero => new(0, 0);

    public readonly Coord Up => new(Row - 1, Col);
    public readonly Coord Right => new(Row, Col + 1);
    public readonly Coord Down => new(Row + 1, Col);
    public readonly Coord Left => new(Row, Col - 1);

    public readonly IEnumerable<Coord> Neighbours => [Up, Right, Down, Left];

    public static Coord operator +(Coord a, Coord b) => new(a.Row + b.Row, a.Col + b.Col);
    public static Coord operator -(Coord a, Coord b) => new(a.Row - b.Row, a.Col - b.Col);

    public static int Manhattan(Coord a, Coord b) =>
        Math.Abs(a.Row - b.Row) + Math.Abs(a.Col - b.Col);

    public override string ToString() => $"({Row}, {Col})";
}

public static class CoordExtensions
{
    public static T Value<T>(this Coord coord, T[][] array) => array[coord.Row][coord.Col];
}