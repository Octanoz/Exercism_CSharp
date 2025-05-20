namespace Alphametics.Validation;

using Alphametics.Processing;
using static Alphametics.HelperMethods.Helpers;

public static class Validator
{
    internal static bool ValidAssigned()
    {
        if (Assigner.assigned.Where(c => c is not '?').CountBy(c => c).Any(kvp => kvp.Value > 1))
            return false;

        int[] nums = SequencesAsInt();

        return Array.TrueForAll(Assigner.sequences, NoLeadingZeroes) && nums[0] + nums[1] == nums[2];
    }

    private static bool NoLeadingZeroes(string s) => AssignedValue(s[0]) is not 0 || s.Length <= 1;
}
