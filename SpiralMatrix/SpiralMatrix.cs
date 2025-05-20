using System.Collections.Generic;
using System.Linq;

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        int enterNum = 1;
        int row = 0;
        int col = 0;
        string direction = "right";

        while (matrix.Cast<int>().Contains(0))
        {
            matrix[row, col] = enterNum++;

            switch (direction)
            {
                case "right":
                    col++;

                    if (col == size || matrix[row, col] != 0)
                    {
                        col--;
                        row++;
                        direction = "down";
                    }
                    break;
                case "down":
                    row++;

                    if (row == size || matrix[row, col] != 0)
                    {
                        row--;
                        col--;
                        direction = "left";
                    }
                    break;
                case "left":
                    col--;

                    if (col < 0 || matrix[row, col] != 0)
                    {
                        col++;
                        row--;
                        direction = "up";
                    }
                    break;
                case "up":
                    row--;

                    if (row < 0 || matrix[row, col] != 0)
                    {
                        row++;
                        col++;
                        direction = "right";
                    }
                    break;
            }
        }

        return matrix;
    }

    public static int[,] GetMatrixClean(int size)
    {
        int[,] matrix = new int[size, size];
        int enterNum = 1;
        int row = 0;
        int col = 0;
        string direction = "right";

        while (matrix.Cast<int>().Contains(0))
        {
            matrix[row, col] = enterNum++;

            // In case of size 1
            if (matrix.Cast<int>().Contains(0))
                break;

            switch (direction)
            {
                case "right":
                    col++;

                    if ((col + 1) == size || matrix[row, col + 1] != 0)
                    {
                        direction = "down";
                    }
                    break;
                case "down":
                    row++;

                    if ((row + 1) == size || matrix[row + 1, col] != 0)
                    {
                        direction = "left";
                    }
                    break;
                case "left":
                    col--;

                    if ((col - 1) < 0 || matrix[row, col - 1] != 0)
                    {
                        direction = "up";
                    }
                    break;
                case "up":
                    row--;

                    if ((row - 1) < 0 || matrix[row - 1, col] != 0)
                    {
                        direction = "right";
                    }
                    break;
            }
        }

        return matrix;
    }

    public static int[,] GetMatrixClean2(int size)
    {
        int[,] matrix = new int[size, size];
        var (enterNum, row, col) = (1, 0, 0);
        Direction direction = Direction.Right;

        //vectors in same order as enum
        int[] deltaRow = { -1, 0, 1, 0 };
        int[] deltaCol = { 0, 1, 0, -1 };

        for (int i = 0; i < (size * size); i++)
        {
            matrix[row, col] = enterNum++;
            int nextRow = row + deltaRow[(int)direction];
            int nextCol = col + deltaCol[(int)direction];

            if (nextRow < 0 || nextRow >= size || nextCol < 0 || nextCol >= size || matrix[nextRow, nextCol] != 0)
            {
                direction = (Direction)(((int)direction + 1) % 4);
                nextRow = row + deltaRow[(int)direction];
                nextCol = col + deltaCol[(int)direction];
            }

            row = nextRow;
            col = nextCol;
        }

        return matrix;
    }

    public static void ShowArrayInfo(Array arr)
    {
        Console.WriteLine("Length of Array:      {0,3}", arr.Length);
        Console.WriteLine("Number of Dimensions: {0,3}", arr.Rank);
        // For multidimensional arrays, show number of elements in each dimension.
        if (arr.Rank > 1)
        {
            for (int dimension = 1; dimension <= arr.Rank; dimension++)
                Console.WriteLine("   Dimension {0}: {1,3}", dimension,
                                  arr.GetUpperBound(dimension - 1) + 1);
        }
        Console.WriteLine();
    }
}
