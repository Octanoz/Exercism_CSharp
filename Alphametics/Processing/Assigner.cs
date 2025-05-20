namespace Alphametics.Processing;

using static Alphametics.Validation.Validator;
using static Alphametics.Assignment.AssignmentManager;
using static Alphametics.HelperMethods.Helpers;

internal static class Assigner
{
    internal static readonly char[] assigned = [.. Enumerable.Repeat('?', 10)];
    internal static string[] sequences = new string[3];
    internal static readonly HashSet<char> presets = [];

    #region Setup

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

    #endregion
    #region Main Processing

    /* private static bool Backtrack(int fromEnd, int carryOver = 0)
    {
        char[] column = ColumnCharacters(fromEnd);
        if (column is ['.', '.', '.'])
            return carryOver is 0 && ValidAssigned();

        int[] setIndices = [.. column.Select(AssignedValue)];

        //All indices already set. Verify that values are a valid addition. Recursively call the next column if so.
        if (AllSetColumn(column, setIndices, carryOver, out int allSetCarryOver))
        {
            return Backtrack(fromEnd + 1, allSetCarryOver);
        }

        return setIndices switch
        {
            var _ when column.Contains('.') => ReducedSet(column, setIndices, carryOver)
                                               .Any(combo => ProcessPartialColumn(column, combo, fromEnd, carryOver)),
            [-1, -1, -1] => NoneSet(column, carryOver).Any(combo => ProcessColumn(column, combo, fromEnd, carryOver)),
            ([_, -1, -1]) or ([-1, _, -1]) or ([-1, -1, _]) => OneSet(column, setIndices, carryOver)
                                                               .Any(combo => ProcessColumn(column, combo, fromEnd, carryOver)),
            ([-1, _, _]) or ([_, -1, _]) or ([_, _, -1]) => TwoSet(setIndices, carryOver)
                                                            .Any(combo => ProcessColumn(column, combo, fromEnd, carryOver)),
            _ => false,
        };
    } */

    /* private static bool ProcessColumn(char[] column, (int, int, int) combo, int fromEnd, int carryOver)
    {
        (bool input1, bool input2, bool result) isAssigned = AssignColumn(column, combo);
        int newCarryOver = CarryOver(combo.Item1, combo.Item2, carryOver);
        if (isAssigned.input1 && isAssigned.input2 && isAssigned.result && Backtrack(fromEnd + 1, newCarryOver))
            return true;

        ResetAssignColumn(combo, isAssigned);
        return false;
    } */

    /* private static bool ProcessPartialColumn(char[] column, (int first, int second, int result) combo, int fromEnd, int carryOver)
    {
        switch (combo)
        {
            case (-2, -2, _):
                bool isAssigned = Assign(column[2], combo.result);
                if (isAssigned && Backtrack(fromEnd + 1))
                    return true;

                ResetAssign(combo.result);
                return false;

            case (-2, _, _):
                var (inputAssigned, resultAssigned) = Assign(column[1], column[2], combo.second, combo.result);
                int newCarryOver = CarryOver(combo.second + carryOver);
                if (inputAssigned && resultAssigned && Backtrack(fromEnd + 1, newCarryOver))
                    return true;

                if (inputAssigned)
                    ResetAssign(combo.second);
                if (resultAssigned)
                    ResetAssign(combo.result);
                return false;

            case (_, -2, _):
                (inputAssigned, resultAssigned) = Assign(column[0], column[2], combo.first, combo.result);
                newCarryOver = CarryOver(combo.first, carryOver);
                if (inputAssigned && resultAssigned && Backtrack(fromEnd + 1, newCarryOver))
                    return true;

                if (inputAssigned)
                    ResetAssign(combo.first);
                if (resultAssigned)
                    ResetAssign(combo.result);
                return false;

            default:
                return false;
        }
    } */

    /* private static bool AllSetColumn(char[] column, int[] setIndices, int carryOver, out int newCarryOver)
    {
        newCarryOver = 0;
        for (int i = 0; i < 3; i++)
        {
            if (column[i] is '.')
                continue;

            if (setIndices[i] is -1 || AssignedAt(setIndices[i]) != column[i])
                return false;
        }

        newCarryOver = AllSetCarryOver(setIndices, carryOver);
        return (setIndices[..2].Where(int.IsPositive).Sum() + carryOver) % 10 == setIndices[2];
    } */

    /* internal static IEnumerable<(int, int, int)> NoneSet(char[] column, int carryOver)
    {
        var indices = Enumerable.Range(0, 10).Where(i => assigned[i] is '?');
        foreach (var firstLine in indices)
        {
            (int first, int second, int result) addition = (firstLine, -1, -1);

            switch (column)
            {
                case [var a, var b, var c] when a == b && a == c:
                    if (carryOver is 0)
                        yield return (firstLine, firstLine, firstLine);
                    break;

                case [var f, var s, _] when f == s:
                    addition.second = firstLine;
                    int resultIndex = ResultFor(addition.first, addition.second, carryOver);
                    if (indices.Contains(resultIndex) && resultIndex != firstLine)
                    {
                        addition.result = resultIndex;
                        yield return addition;
                    }
                    break;

                case [var f, _, var r] when f == r:
                    addition.result = firstLine;
                    int secondIndex = InputFor(addition.result, addition.first, carryOver);
                    if (indices.Contains(secondIndex) && secondIndex != firstLine)
                    {
                        addition.second = secondIndex;
                        yield return addition;
                    }
                    break;

                //second and result are equal but their value has not been determined yet. Therefore foreach loop is valid.
                case [_, var s, var r] when s == r:
                    foreach (var duplicate in indices.Where(dup => dup != firstLine && ResultFor(firstLine, dup, carryOver) == dup))
                    {
                        (addition.second, addition.result) = (duplicate, duplicate);
                        yield return addition;
                    }
                    break;

                default:
                    foreach (var secondLine in indices.Where(sl => sl != firstLine))
                    {
                        int resultLine = (firstLine + secondLine + carryOver) % 10;
                        if (assigned[resultLine] is '?' && secondLine != resultLine)
                        {
                            (addition.second, addition.result) = (secondLine, resultLine);
                            yield return addition;
                        }
                    }
                    break;
            }
        }
    }

    internal static IEnumerable<(int, int, int)> OneSet(char[] column, int[] setIndices, int carryOver)
    {
        var indices = Enumerable.Range(0, 10).Where(i => assigned[i] is '?');
        (int first, int second, int result) addition = (setIndices[0], setIndices[1], setIndices[2]);
        switch (column, setIndices)
        {
            case ([_, var input, var res], [var i, -1, -1]) when input == res && i >= 0:
            case ([var input2, _, var res2], [-1, var idx, -1]) when input2 == res2 && idx >= 0:
                foreach (var duplicate in indices.Where(dup => ResultFor(setIndices.Max(), dup, carryOver) == dup))
                {
                    yield return setIndices[0] switch
                    {
                        -1 => (duplicate, setIndices[1], duplicate),
                        _ => (setIndices[0], duplicate, duplicate)
                    };
                }
                break;

            case (_, [var x, -1, -1]) when x >= 0:
                foreach (var index in indices.Where(i => indices.Contains(ResultFor(x, i, carryOver))))
                {
                    addition.second = index;
                    addition.result = ResultFor(addition.first, addition.second, carryOver);
                    yield return addition;
                }
                break;

            case (_, [-1, var x, -1]) when x >= 0:
                foreach (var index in indices.Where(i => indices.Contains(ResultFor(i, x, carryOver))))
                {
                    addition.first = index;
                    addition.result = ResultFor(addition.first, addition.second, carryOver);
                    yield return addition;
                }
                break;

            case (_, [-1, -1, var x]) when x >= 0:
                foreach (var index in indices.Where(i => indices.Contains(InputFor(x, i, carryOver))))
                {
                    addition.first = index;
                    addition.second = InputFor(addition.result, addition.first, carryOver);
                    yield return addition;
                }
                break;
        }
    }

    internal static IEnumerable<(int, int, int)> TwoSet(int[] setIndices, int carryOver)
    {
        var indices = Enumerable.Range(0, 10).Where(i => assigned[i] is '?');
        (int first, int second, int result) addition = (setIndices[0], setIndices[1], setIndices[2]);
        switch (setIndices)
        {
            case [-1, _, _]:
                int fIndex = InputFor(addition.result, addition.second, carryOver);
                if (indices.Contains(fIndex))
                {
                    addition.first = fIndex;
                    yield return addition;
                }
                break;

            case [_, -1, _]:
                int sIndex = InputFor(addition.result, addition.first, carryOver);
                if (indices.Contains(sIndex))
                {
                    addition.second = sIndex;
                    yield return addition;
                }
                break;

            case [_, _, -1]:
                int rIndex = ResultFor(addition.first, addition.second, carryOver);
                if (indices.Contains(rIndex))
                {
                    addition.result = rIndex;
                    yield return addition;
                }
                break;
        }
    } */

    //Processes column with 1 or 2 missing elements (due to out of bounds)
    //Indices for these elements are set to -2 to make it clear they are intentionally negative
    /* internal static IEnumerable<(int, int, int)> ReducedSet(char[] column, int[] setIndices, int carryOver)
    {
        var indices = Enumerable.Range(0, 10).Where(i => assigned[i] is '?');
        switch (column, setIndices)
        {
            case (['.', '.', _], [-1, -1, _]):
                if (carryOver is 1 && (AssignedValue(column[2]) is 1 || indices.Contains(carryOver)))
                    yield return (-2, -2, carryOver);
                break;

            case (['.', var s, var r], [-1, -1, -1]) when s == r:
            case ([var fst, '.', var res], [-1, -1, -1]) when fst == res:
                foreach (var duplicate in indices.Where(dup => ResultFor(dup, carryOver) == dup))
                {
                    yield return Array.IndexOf(column, '.') switch
                    {
                        0 => (-2, duplicate, duplicate),
                        1 => (duplicate, -2, duplicate)
                    };
                }
                break;

            case (['.', _, _], [-1, -1, -1]):
                foreach (var index in indices.Where(i => indices.Contains(ResultFor(i, carryOver))))
                    yield return (-2, index, ResultFor(index, carryOver));
                break;

            case (['.', _, _], [-1, _, -1]):
                if (carryOver is 1 && indices.Contains(ResultFor(setIndices[1], carryOver)))
                    yield return (-2, setIndices[1], ResultFor(setIndices[1], carryOver));
                break;

            case (['.', _, _], [-1, -1, _]):
                if (carryOver is 1 && indices.Contains(InputFor(setIndices[2], carryOver)))
                    yield return (-2, InputFor(setIndices[2], carryOver), setIndices[2]);
                break;

            case ([_, '.', _], [-1, -1, -1]):
                foreach (var index in indices.Where(i => indices.Contains(ResultFor(i, carryOver))))
                    yield return (index, -2, ResultFor(index, carryOver));
                break;

            case ([_, '.', _], [_, -1, -1]):
                if (carryOver is 1 && indices.Contains(ResultFor(setIndices[0], carryOver)))
                    yield return (setIndices[0], -2, ResultFor(setIndices[0], carryOver));
                break;

            case ([_, '.', _], [-1, -1, _]):
                if (carryOver is 1 && indices.Contains(InputFor(setIndices[2], carryOver)))
                    yield return (InputFor(setIndices[2], carryOver), -2, setIndices[2]);
                break;
        }
    } */

    #endregion
    #region Validation

    /* internal static bool ValidAssigned()
    {
        if (assigned.Where(c => c is not '?').CountBy(c => c).Any(kvp => kvp.Value > 1))
            return false;

        int[] nums = SequencesAsInt();

        return Array.TrueForAll(sequences, NoLeadingZeroes) && nums[0] + nums[1] == nums[2];
    }

    private static bool NoLeadingZeroes(string s) => AssignedValue(s[0]) is not 0 || s.Length <= 1; */

    #endregion
    #region Assign and Reset

    /* internal static bool Assign(char c, int index)
    {
        if (AssignedAt(index) == c)
            return true;

        if (assigned[index] != '?' || AssignedValue(c) != -1)
            return false;

        assigned[index] = c;
        return true;
    }

    internal static (bool, bool) Assign(char c1, char c2, int index1, int index2) => (Assign(c1, index1), Assign(c2, index2));

    internal static (bool, bool, bool) AssignColumn(char[] column, (int first, int second, int result) indices) =>
        (Assign(column[0], indices.first), Assign(column[1], indices.second), Assign(column[2], indices.result));

    internal static void ResetAssign(int index)
    {
        if (!presets.Contains(AssignedAt(index)))
            assigned[index] = '?';
    }

    internal static void ResetAssign(int index1, int index2)
    {
        ResetAssign(index1);
        ResetAssign(index2);
    }

    internal static void ResetAssignColumn((int first, int second, int result) indices, (bool first, bool second, bool result) wasChanged)
    {
        if (wasChanged.first)
            ResetAssign(indices.first);
        if (wasChanged.second)
            ResetAssign(indices.second);
        if (wasChanged.result)
            ResetAssign(indices.result);
    } */

    #endregion
    #region Helper Functions

    /* internal static char AssignedAt(int n) => n is >= 0 and < 10 ? assigned[n] : 'x';
    internal static int AssignedValue(char c) => Array.IndexOf(assigned, c);

    internal static int[] SequencesAsInt() =>
        [.. sequences.Select(s => s.Aggregate(0, (acc, elem) => acc * 10 + Array.IndexOf(assigned, elem)))];

    internal static char[] ColumnCharacters(int fromEnd) =>
        [.. sequences.Select(s => s.Length < fromEnd ? '.' : s[^fromEnd])];

    private static int ResultFor(params int[] input) => input.Sum() % 10;
    private static int InputFor(params int[] input) => (input[0] + 10 - input[1..].Sum()) % 10;
    private static int CarryOver(params int[] input) => input.Sum() / 10;
    private static int AllSetCarryOver(int[] indices, int carryOver) =>
        (indices[..2].Where(n => n > 0).Sum() + carryOver) / 10;

    internal static void SetSequences(params string[] inputs) =>
        sequences = inputs.Length is 3 && inputs[^1].Length == inputs.Max(s => s.Length)
                  ? inputs
                  : throw new ArgumentException($"Invalid input sequence: [ {String.Join(", ", inputs)} ]");

    internal static void ResetCollections()
    {
        Array.Fill(assigned, '?');
        Array.Fill(sequences, "");
    } */

    #endregion
}

