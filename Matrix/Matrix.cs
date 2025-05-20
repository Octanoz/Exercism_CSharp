namespace TheMatrix;

public class Matrix(string input)
{
    public int[][] Internal { get; } = 
        [.. input.Split("\n").Select(s => Array.ConvertAll(s.Split(), int.Parse))];

    public int[] Row(int row) => [.. Internal[row - 1]];

    public int[] Column(int col) =>
        [.. Internal.Select(arr => arr[col - 1])];
}
