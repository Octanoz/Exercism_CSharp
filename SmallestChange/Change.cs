namespace SmallestChange;

public static class Change
{
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target is 0)
            return [];

        int[]? shortestSequence = null;
        HashSet<(int, int)> used = [];
        int minLength = target / coins.Min() + 1;
        Array.Sort(coins, (x, y) => y.CompareTo(x));
        foreach (var coin in coins.Where(c => c <= target))
        {
            Backtrack(coins, target - coin, [coin]);
        }

        return shortestSequence?.Order().ToArray()
            ?? throw new ArgumentException("No possible combination found.");

        void Backtrack(int[] coins, int target, int[] sequence)
        {
            if (!used.Add((sequence.Length, sequence.Sum()))
            || sequence.Length >= minLength)
            {
                return;
            }

            if (target is 0)
            {
                shortestSequence = sequence;
                minLength = sequence.Length;
                return;
            }

            foreach (var coin in coins.Where(c => c <= target))
            {
                Backtrack(coins, target - coin, [coin, .. sequence]);
            }

            return;
        }
    }

    public static int[] CoinChange(int[] coins, int target)
    {
        if (target < 0)
            throw new ArgumentException("Target must be non-negative.");

        if (target == 0)
            return [];

        int n = coins.Length;
        int startValue = target * 2;
        int[,] dp = new int[n + 1, target + 1];

        // Initialize the first row to a large number
        for (int j = 1; j <= target; j++)
            dp[0, j] = startValue;

        // First column is initialized to 0 as no coins are needed to make amount 0
        for (int i = 0; i <= n; i++)
            dp[i, 0] = 0;

        // Fill the DP table
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                if (coins[i - 1] <= j)
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - coins[i - 1]] + 1);
                else
                    dp[i, j] = dp[i - 1, j];
            }
        }

        // If no solution exists last column of last row will be startValue
        if (dp[n, target] == startValue)
            throw new ArgumentException("No possible combination found.");

        // Reconstruct the result from the DP table
        List<int> result = [];
        int coinIndex = n - 1;
        int amount = target;

        while (coinIndex >= 0 && amount > 0)
        {
            //Compare current steps with previous row,
            //if previous value is the same as this one then this coin was not used, move up
            if (dp[coinIndex + 1, amount] != dp[coinIndex, amount])
            {
                result.Add(coins[coinIndex]);
                amount -= coins[coinIndex];
            }
            else coinIndex--;

        }

        result.Sort();
        return [.. result];
    }
}
