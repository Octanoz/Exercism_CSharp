namespace Alphametics.Processing;

using Alphametics.Processing.PartialProcessing;
using Alphametics.Validation;
using static Alphametics.HelperMethods.Helpers;

internal static class BacktrackSolver
{
    internal static bool Backtrack(int fromEnd, int carryOver = 0)
    {
        char[] column = ColumnCharacters(fromEnd);
        if (column is ['.', '.', '.'])
            return carryOver is 0 && Validator.ValidAssigned();

        int[] setIndices = [.. column.Select(AssignedValue)];

        //All indices already set. Verify that values are a valid addition. Recursively call the next column if so.
        if (ColumnProcessor.AllSetColumn(column, setIndices, carryOver, out int allSetCarryOver))
        {
            return Backtrack(fromEnd + 1, allSetCarryOver);
        }

        return setIndices switch
        {
            var _ when column.Contains('.') => PartialValueGenerator.ReducedSet(column, setIndices, carryOver)
                                               .Any(combo => PartialColumnProcessor.ProcessPartialColumn(column, combo, fromEnd, carryOver)),

            [-1, -1, -1] => ValueGenerator.NoneSet(column, carryOver)
                            .Any(combo => ColumnProcessor.ProcessColumn(column, combo, fromEnd, carryOver)),

            [_, -1, -1] or [-1, _, -1] or [-1, -1, _] => ValueGenerator.OneSet(column, setIndices, carryOver)
                                                         .Any(combo => ColumnProcessor.ProcessColumn(column, combo, fromEnd, carryOver)),

            [-1, _, _] or [_, -1, _] or [_, _, -1] => ValueGenerator.TwoSet(setIndices, carryOver)
                                                      .Any(combo => ColumnProcessor.ProcessColumn(column, combo, fromEnd, carryOver)),
            _ => false,
        };
    }
}
