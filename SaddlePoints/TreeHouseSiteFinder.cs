namespace SaddlePoints;

public static class TreeHouseSiteFinder
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        int maxRow = matrix.GetLength(0);
        int maxCol = matrix.GetLength(1);
        int[] maxInRow = new int[maxRow];
        for (int rowIndex = 0; rowIndex < maxRow; rowIndex++)
        {
            maxInRow[rowIndex] = GetHighestInRow(maxCol, rowIndex, matrix);
        }

        for (int colIndex = 0; colIndex < maxCol; colIndex++)
        {
            foreach (var (row, col) in GetLowestInColumn(maxRow, maxCol, colIndex, matrix, maxInRow))
            {
                yield return (row + 1, col + 1); //results should be 1-indexed
            }
        }
    }

    private static IEnumerable<(int, int)> GetLowestInColumn(int maxRow, int maxCol, int col, int[,] matrix, int[] maxInRow)
    {
        if (col < 0 || col >= maxCol)
        {
            throw new ArgumentException($"Invalid column requested: {col}, Matrix is only {maxCol} columns wide");
        }

        int min = int.MaxValue;
        for (int row = 0; row < maxRow; row++)
        {
            min = Math.Min(min, matrix[row, col]);
        }

        for (int row = 0; row < maxRow; row++)
        {
            if (matrix[row, col] == min && maxInRow[row] == min)
            {
                yield return (row, col);
            }
        }
    }

    private static int GetHighestInRow(int maxCol, int row, int[,] matrix) => RowValues(maxCol, row, matrix).Max();

    private static IEnumerable<int> RowValues(int maxCol, int row, int[,] matrix)
    {
        for (int col = 0; col < maxCol; col++)
        {
            yield return matrix[row, col];
        }
    }
}
