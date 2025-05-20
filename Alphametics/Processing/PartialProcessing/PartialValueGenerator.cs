namespace Alphametics.Processing.PartialProcessing;

using Alphametics.Processing;
using static Alphametics.HelperMethods.Helpers;

internal static class PartialValueGenerator
{
    internal static IEnumerable<(int, int, int)> ReducedSet(char[] column, int[] setIndices, int carryOver)
    {
        var indices = Enumerable.Range(0, 10).Where(i => Assigner.assigned[i] is '?');
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
    }
}
