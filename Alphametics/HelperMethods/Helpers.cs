namespace Alphametics.HelperMethods;

using Alphametics.Processing;


public static class Helpers
{
    internal static char AssignedAt(int n) => n is >= 0 and < 10 ? Assigner.assigned[n] : 'x';
    internal static int AssignedValue(char c) => Array.IndexOf(Assigner.assigned, c);

    internal static int[] SequencesAsInt() =>
        [.. Assigner.sequences.Select(s => s.Aggregate(0, (acc, elem) => acc * 10 + Array.IndexOf(Assigner.assigned, elem)))];

    internal static char[] ColumnCharacters(int fromEnd) =>
        [.. Assigner.sequences.Select(s => s.Length < fromEnd ? '.' : s[^fromEnd])];

    internal static int ResultFor(params int[] input) => input.Sum() % 10;
    internal static int InputFor(params int[] input) => (input[0] + 10 - input[1..].Sum()) % 10;
    internal static int CarryOver(params int[] input) => input.Sum() / 10;
    internal static int AllSetCarryOver(int[] indices, int carryOver) =>
        (indices[..2].Where(n => n > 0).Sum() + carryOver) / 10;

    internal static void SetSequences(params string[] inputs) =>
        Assigner.sequences = inputs.Length is 3 && inputs[^1].Length == inputs.Max(s => s.Length)
                           ? inputs
                           : throw new ArgumentException($"Invalid input sequence: [ {String.Join(", ", inputs)} ]");

    internal static void ResetCollections()
    {
        Array.Fill(Assigner.assigned, '?');
        Array.Fill(Assigner.sequences, "");
    }

}
