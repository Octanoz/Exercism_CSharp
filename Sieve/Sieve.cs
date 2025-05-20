using System.Collections;

namespace Eratosthenes;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 0)
            throw new ArgumentOutOfRangeException("Primes can't be negative");
        if (limit < 2)
            return [];
        if (limit == 2)
            return [2];

        List<int> possibleNumbers = [2, 3];
        int currentIndex = 1;
        while (possibleNumbers[currentIndex] + 2 <= limit)
        {
            possibleNumbers.Add(possibleNumbers[currentIndex++] + 2);
        }

        bool[] markers = new bool[possibleNumbers.Count];
        markers = markers.Select(b => b).ToArray();

        for (int i = 1; possibleNumbers[i] * possibleNumbers[i] <= limit; i++)
        {
            int j = i;
            int step = possibleNumbers[i];
            while (j + step < markers.Length)
            {
                j += step;
                markers[j] = false;
            }
        }

        List<int> primes = [2, 3];

        for (int i = 2; i < possibleNumbers.Count; i++)
        {
            if (markers[i])
                primes.Add(possibleNumbers[i]);
        }

        return [.. primes];
    }

    public static int[] PrimesSquares(int limit)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(limit);

        bool[] numbers = Enumerable.Repeat(true, limit + 1).ToArray();
        numbers[0] = false;

        for (int i = 0; i <= Math.Sqrt(limit); i++)
        {
            int step = i * i;
            while (numbers[i] && i * i + step <= limit)
            {
                numbers[step] = false;
                step += i;
            }
        }

        return numbers.Select((b, i) => b ? i : -1).Where(i => i > 0).ToArray();
    }

    public static IEnumerable<int> PrimesBit(int limit)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(limit);

        BitArray primes = new(limit + 1, true);
        for (int i = 2; i <= limit; i++)
        {
            if (!primes[i])
                continue;

            for (int j = i * 2; j <= limit; j += i)
            {
                primes[j] = false;
            }

            yield return i;
        }
    }

    public static IEnumerable<int> PrimesBitSquares(int limit)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(limit);

        BitArray primes = new(limit + 1, true);

        for (int i = 0; i <= limit; i++)
        {
            int step = i * i;
            while (primes[i] && step <= limit)
            {
                primes[step] = false;
                step += i;
            }

            if (primes[i])
                yield return i;
        }
    }
}