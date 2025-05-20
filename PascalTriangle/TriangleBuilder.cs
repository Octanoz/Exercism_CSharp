using System.Text;

namespace PascalTriangle;

public static class TriangleBuilder
{
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        int[][] pyramidRows = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            pyramidRows[i] = new int[i + 1];
            pyramidRows[i][0] = 1;
            pyramidRows[i][i] = 1;

            for (int j = 1; j < i; j++)
            {
                int num1 = pyramidRows[i - 1][j - 1];
                int num2 = pyramidRows[i - 1][j];
                pyramidRows[i][j] = num1 + num2;
            }
        }

        return [.. pyramidRows];
    }
}