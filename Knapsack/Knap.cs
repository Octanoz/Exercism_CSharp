using System.Buffers;

namespace Knap;

public static class Knapsack
{
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] sackItems)
    {
        List<Item> items = [];

        foreach (var (weight, value) in sackItems)
        {
            items.Add(new(weight, value));
        }

        while (items.Sum(i => i.Weight) > maximumWeight)
        {
            items.Remove(items.OrderBy(i => i.ValuePerWeight).First());
        }

        return items.Sum(i => i.Value);
    }

    public static int MaximumValueX(int maximumWeight, (int weight, int value)[] sackItems)
    {
        List<Item> items = [];

        foreach (var (weight, value) in sackItems)
        {
            items.Add(new(weight, value));
        }

        items = items.OrderBy(i => i.ValuePerWeight).ToList();

        Queue<Item> knapsack = [];
        int maxValue = 0;

        while (items.Count > 0)
        {
            knapsack.Enqueue(items[0]);
            items.RemoveAt(0);

            while (knapsack.Sum(i => i.Weight) > maximumWeight)
            {
                knapsack.Dequeue();
            }

            maxValue = Math.Max(maxValue, knapsack.Sum(i => i.Value));
        }

        return maxValue;
    }

    public static int MaximumValue3(int maximumWeight, (int weight, int value)[] sackItems) => MaxValueRecursive(sackItems, sackItems.Length - 1, maximumWeight, []);

    static int MaxValueRecursive((int weight, int value)[] sackItems, int index, int remainingWeight, Dictionary<(int, int), int> memo)
    {
        if (index < 0 || remainingWeight <= 0)
            return 0;

        var key = (index, remainingWeight);

        if (memo.TryGetValue(key, out int storedValue))
            return storedValue;

        if (sackItems[index].weight > remainingWeight)
        {
            memo[key] = MaxValueRecursive(sackItems, index - 1, remainingWeight, memo);
            return memo[key];
        }
        else
        {
            int includeItem = sackItems[index].value + MaxValueRecursive(sackItems, index - 1, remainingWeight - sackItems[index].weight, memo);
            int excludeItem = MaxValueRecursive(sackItems, index - 1, remainingWeight, memo);

            memo[key] = Math.Max(includeItem, excludeItem);

            return memo[key];
        }

    }
}

public class Item(int weight, int value)
{
    public int Weight { get; } = weight;
    public int Value { get; } = value;
    public double ValuePerWeight { get; } = (double)value / weight;
}
