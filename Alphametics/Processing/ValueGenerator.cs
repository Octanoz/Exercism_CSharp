namespace Alphametics.Processing;

using static Alphametics.HelperMethods.Helpers;

public static class ValueGenerator
{
    internal static IEnumerable<(int, int, int)> NoneSet(char[] column, int carryOver)
    {
        var indices = Enumerable.Range(0, 10).Where(i => AssignedAt(i) is '?');
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
                        if (Assigner.assigned[resultLine] is '?' && secondLine != resultLine)
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
        var indices = Enumerable.Range(0, 10).Where(i => AssignedAt(i) is '?');
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
        var indices = Enumerable.Range(0, 10).Where(i => AssignedAt(i) is '?');
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
    }
}
