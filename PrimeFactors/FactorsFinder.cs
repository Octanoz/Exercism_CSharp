namespace PrimeFactors;

public static class FactorsFinder
{
    public static long[] Factors(long number)
    {
        List<long> factors = [];
        int factor = 2;

        while (number is not 1)
        {
            if (number % factor is 0)
            {
                factors.Add(factor);
                number /= factor;
            }
            else factor++;
        }

        return [.. factors];
    }
}