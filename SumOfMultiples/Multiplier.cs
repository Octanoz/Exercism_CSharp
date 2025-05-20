namespace SumOfMultiples;

public static class Multiplier
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        HashSet<int> result = [];

        foreach (var multiple in multiples)
        {
            for (int i = 1; multiple * i < max; i++)
            {
                result.Add(multiple * i);
            }
        }

        return result.Sum();
    }

    public static int SumAlt(IEnumerable<int> multiples, int max)
    {
        //Iterate through the enumerable range and check for every number if it can be divided by ANY multiple, if so - add it to the sum.
        return Enumerable.Range(1, max - 1)
                        .Where(x => multiples.Any(y => y != 0 && x % y == 0))
                        .Sum();
    }

    public static int SumLinq(IEnumerable<int> multiples, int max)
    {
        //For all values in multiples, find all unique multiples that are less than max and return the sum
        return multiples.SelectMany(multiple => Enumerable.Range(1, (max - 1) / multiple)
                        .Select(i => i * multiple))
                        .Distinct()
                        .Sum();
    }


}