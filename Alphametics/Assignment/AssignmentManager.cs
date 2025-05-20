namespace Alphametics.Assignment;

using Alphametics.Processing;
using static Alphametics.HelperMethods.Helpers;

internal static class AssignmentManager
{
    internal static bool Assign(char c, int index)
    {
        if (AssignedAt(index) == c)
            return true;

        if (Assigner.assigned[index] != '?' || AssignedValue(c) != -1)
            return false;

        Assigner.assigned[index] = c;
        return true;
    }

    internal static (bool, bool) Assign(char c1, char c2, int index1, int index2) => (Assign(c1, index1), Assign(c2, index2));

    internal static (bool, bool, bool) AssignColumn(char[] column, (int first, int second, int result) indices) =>
        (Assign(column[0], indices.first), Assign(column[1], indices.second), Assign(column[2], indices.result));

    internal static void ResetAssign(int index)
    {
        if (!Assigner.presets.Contains(AssignedAt(index)))
            Assigner.assigned[index] = '?';
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
    }

}
