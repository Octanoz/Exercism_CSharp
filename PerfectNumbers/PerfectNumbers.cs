namespace PerfectNumbers;

public static class Solution
{
    public static Classification Classify(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException(nameof(number));
        if (number == 1)
            return Classification.Deficient;

        List<int> factors = [1];
        int highestFactor = number / 2;

        for (int i = 2; i < highestFactor; i++)
        {
            if (number % i == 0)
            {
                if (factors.Contains(i))
                    break;
                else
                {
                    factors.Add(i);
                    factors.Add(number / i);
                }
            }
        }

        Console.WriteLine($"[{String.Join(", ", factors)}]");

        return number == factors.Sum() ? Classification.Perfect :
                number < factors.Sum() ? Classification.Abundant : Classification.Deficient;
    }

    public static Classification ClassifyLinq(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException(nameof(number));
        if (number == 1)
            return Classification.Deficient;

        var factorSum = Enumerable.Range(1, number / 2)
                                        .Where(f => number % f == 0)
                                        .Sum();

        return number == factorSum ? Classification.Perfect :
                number < factorSum ? Classification.Abundant : Classification.Deficient;
    }
}

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}