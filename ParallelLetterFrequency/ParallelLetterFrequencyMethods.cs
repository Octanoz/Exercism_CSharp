using System.Collections.Concurrent;

namespace ParallelLetterFrequency;

public static class ParallelLetterFrequencyMethods
{
    public static Dictionary<char, int> Calculate(IEnumerable<string> texts)
    {
        ConcurrentDictionary<char, int> letterFrequency = [];

        Parallel.ForEach(texts.SelectMany(text => text.ToLower()), letter =>
        {
            if (Char.IsLetter(letter))
                letterFrequency.AddOrUpdate(letter, 1, (_, existingValue) => existingValue + 1);
        });

        return letterFrequency.ToDictionary(kvp => kvp.Key, kpv => kpv.Value);
    }

    public static Dictionary<char, int> CalculateLinq(IEnumerable<string> texts)
    {
        return texts.AsParallel()
                    .SelectMany(text => text.ToLower())
                    .Where(Char.IsLetter)
                    .GroupBy(c => c)
                    .ToDictionary(group => group.Key, letter => letter.Count());
    }
}