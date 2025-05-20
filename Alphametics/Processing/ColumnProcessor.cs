namespace Alphametics.Processing;

using static Alphametics.Assignment.AssignmentManager;
using static Alphametics.HelperMethods.Helpers;

public static class ColumnProcessor
{
    internal static bool ProcessColumn(char[] column, (int, int, int) combo, int fromEnd, int carryOver)
    {
        (bool input1, bool input2, bool result) isAssigned = AssignColumn(column, combo);
        int newCarryOver = CarryOver(combo.Item1, combo.Item2, carryOver);
        if (isAssigned.input1 && isAssigned.input2 && isAssigned.result && BacktrackSolver.Backtrack(fromEnd + 1, newCarryOver))
            return true;

        ResetAssignColumn(combo, isAssigned);
        return false;
    }

    internal static bool AllSetColumn(char[] column, int[] setIndices, int carryOver, out int newCarryOver)
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
    }
}
