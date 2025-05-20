namespace Alphametics.Processing.PartialProcessing;

using Alphametics.Processing;
using Alphametics.Assignment;
using static Alphametics.HelperMethods.Helpers;

public static class PartialColumnProcessor
{
    internal static bool ProcessPartialColumn(char[] column, (int first, int second, int result) combo, int fromEnd, int carryOver)
    {
        switch (combo)
        {
            case (-2, -2, _):
                bool isAssigned = AssignmentManager.Assign(column[2], combo.result);
                if (isAssigned && BacktrackSolver.Backtrack(fromEnd + 1))
                    return true;

                AssignmentManager.ResetAssign(combo.result);
                return false;

            case (-2, _, _):
                var (inputAssigned, resultAssigned) = AssignmentManager.Assign(column[1], column[2], combo.second, combo.result);
                int newCarryOver = CarryOver(combo.second + carryOver);
                if (inputAssigned && resultAssigned && BacktrackSolver.Backtrack(fromEnd + 1, newCarryOver))
                    return true;

                if (inputAssigned)
                    AssignmentManager.ResetAssign(combo.second);
                if (resultAssigned)
                    AssignmentManager.ResetAssign(combo.result);
                return false;

            case (_, -2, _):
                (inputAssigned, resultAssigned) = AssignmentManager.Assign(column[0], column[2], combo.first, combo.result);
                newCarryOver = CarryOver(combo.first, carryOver);
                if (inputAssigned && resultAssigned && BacktrackSolver.Backtrack(fromEnd + 1, newCarryOver))
                    return true;

                if (inputAssigned)
                    AssignmentManager.ResetAssign(combo.first);
                if (resultAssigned)
                    AssignmentManager.ResetAssign(combo.result);
                return false;

            default:
                return false;
        }
    }
}
