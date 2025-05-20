namespace Alphametics.Processing;

using static Alphametics.Assignment.AssignmentManager;
using static Alphametics.HelperMethods.Helpers;

internal static class Assigner
{
    internal static readonly char[] assigned = [.. Enumerable.Repeat('?', 10)];
    internal static string[] sequences = new string[3];
    internal static readonly HashSet<char> presets = [];

    internal static int[] AssignNumbers(string input1, string input2, string result)
    {
        SetSequences(input1, input2, result);

        Prechecks();

        if (BacktrackSolver.Backtrack(1))
        {
            return SequencesAsInt();
        }

        Console.WriteLine($"Finished backtracking without a solution found.");

        return [];
    }

    //Looks for obvious cases where a 1 or a 9 can be set
    //Also stores the values in presets which is checked in ResetAssign to prevent resets
    private static void Prechecks()
    {
        var (firstLength, secondLength, resultLength) =
            (sequences[0].Length, sequences[1].Length, sequences[2].Length);

        bool resultIsLongest = resultLength > firstLength && resultLength > secondLength;
        if (resultIsLongest)
        {
            Assign(sequences[2][0], 1);
            presets.Add(sequences[2][0]);
        }

        if (firstLength != secondLength)
        {
            char first = firstLength > secondLength
                       ? sequences[0][0]
                       : sequences[1][0];

            if (resultIsLongest)
            {
                //If input lines are of different lengths and the result is longer still
                //The longest input line has to start with a 9
                Assign(first, 9);
                presets.Add(first);
            }
        }
    }
}

