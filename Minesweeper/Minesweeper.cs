namespace Games;

public static class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        int rows = input.Length;
        int cols = input[0].Length;
        string[] result = new string[rows];
        Span<char> span = stackalloc char[cols];

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (input[row][col] == '*')
                {
                    span[col] = '*';
                }
                else
                {
                    List<(int row, int col)> neighbours = GetNeighbours(row, col, rows, cols);
                    int mines = neighbours.Count(nb => input[nb.row][nb.col] is '*');

                    span[col] = mines is 0 ? (char)32 : (char)(mines + '0');
                }
            }

            result[row] = new(span);
        }

        return result;
    }

    private static List<(int, int)> GetNeighbours(int row, int col, int maxRow, int maxCol)
    {
        List<(int, int)> neighbours = [];
        int[] deltaRow = [-1, -1, -1, 0, 0, 1, 1, 1];
        int[] deltaCol = [-1, 0, 1, -1, 1, -1, 0, 1];

        for (int i = 0; i < 8; i++)
        {
            int newRow = row + deltaRow[i];
            int newCol = col + deltaCol[i];

            if (newRow >= 0 && newRow < maxRow
            && newCol >= 0 && newCol < maxCol)
            {
                neighbours.Add((newRow, newCol));
            }
        }

        return neighbours;
    }
}
