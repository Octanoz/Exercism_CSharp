using System.Collections.Concurrent;

namespace Rectangles;

public static class RectangleCounter
{
    public static int Count(string[] input)
    {
        if (input.Length is 0)
            return 0;

        char[][] grid = input.Select(row => row.ToCharArray()).ToArray();

        var corners = input.Index().SelectMany(row => row.Item.Index()
                                        .Where(col => col.Item is '+')
                                        .Select(col => new Coord(row.Index, col.Index)))
                                        .ToArray();

        return ValidRectanglesParallel(corners, grid);
    }

    private static bool ValidHorizontal(Coord left, Coord right, char[][] grid)
    {
        if (right.Row != left.Row || right.Col <= left.Col)
            return false;

        if (left.Row == right.Row && Coord.Manhattan(left, right) is 1)
            return true;

        while (left.Col != right.Col)
        {
            if (left.Right.Value(grid) is '-' or '+')
            {
                left = left.Right;
            }
            else return false;
        }

        return true;
    }

    private static bool ValidVertical(Coord top, Coord bottom, char[][] grid)
    {
        if (bottom.Col != top.Col || bottom.Row <= top.Row)
            return false;

        if (top.Col == bottom.Col && Coord.Manhattan(top, bottom) is 1)
            return true;

        while (top.Row != bottom.Row)
        {
            if (top.Down.Value(grid) is '|' or '+')
            {
                top = top.Down;
            }
            else return false;
        }

        return true;
    }

    private static int ValidRectangles(Coord[] corners, char[][] grid)
    {
        int result = 0;
        foreach (var topLeft in corners.Where(c => c.Row < grid.Length - 1))
        {
            Coord[] bottomLefts = corners.Where(c => ValidVertical(topLeft, c, grid)).ToArray();
            if (bottomLefts.Length is 0)
                continue;

            foreach (var topRight in corners.Where(c => ValidHorizontal(topLeft, c, grid)))
            {
                Coord[] bottomRights = corners.Where(c => ValidVertical(topRight, c, grid)).ToArray();
                if (bottomRights.Length is 0)
                    continue;

                foreach (var bottomLeft in bottomLefts)
                {
                    foreach (var bottomRight in bottomRights.Where(c => ValidHorizontal(bottomLeft, c, grid)))
                    {
                        result++;
                    }
                }
            }
        }

        return result;
    }

    private static int ValidRectanglesAlt(Coord[] corners, char[][] grid)
    {
        return (from topLeft in corners
                let bottomLefts = corners.Where(c => ValidVertical(topLeft, c, grid))
                where bottomLefts.Any()
                from topRight in corners.Where(c => ValidHorizontal(topLeft, c, grid))
                let bottomRights = corners.Where(c => ValidVertical(topRight, c, grid))
                where bottomRights.Any()
                from bottomLeft in bottomLefts
                from bottomRight in bottomRights.Where(c => ValidHorizontal(bottomLeft, c, grid))
                select 1).Count();
    }

    private static int ValidRectanglesParallel(Coord[] corners, char[][] grid)
    {
        ConcurrentBag<int> resultBag = [];

        Parallel.ForEach(corners, topLeft =>
        {
            var bottomLefts = corners.Where(c => ValidVertical(topLeft, c, grid)).ToArray();
            if (bottomLefts.Length is 0)
                return;

            foreach (var topRight in corners.Where(c => ValidHorizontal(topLeft, c, grid)))
            {
                var bottomRights = corners.Where(c => ValidVertical(topRight, c, grid)).ToArray();
                if (bottomRights.Length is 0)
                    continue;

                foreach (var bottomLeft in bottomLefts)
                {
                    foreach (var bottomRight in bottomRights.Where(c => ValidHorizontal(bottomLeft, c, grid)))
                    {
                        resultBag.Add(1);
                    }
                }
            }
        });

        return resultBag.Count;
    }
}
