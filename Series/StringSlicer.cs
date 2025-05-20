namespace Series;

public static class StringSlicer
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength > numbers.Length || sliceLength <= 0)
            throw new ArgumentException($"Slice length must be at least 1 and less or equal to the input length.");

        List<string> result = [];
        int len = numbers.Length - (sliceLength - 1);

        for (int i = 0; i < len; i++)
        {
            result.Add(numbers[i..(i + sliceLength)]);
        }

        return [.. result];
    }

    public static string[] SlicesLinq(string numbers, int sliceLength)
    {
        return numbers.Take(numbers.Length - (sliceLength - 1))
                        .Select((_, i) => numbers[i..(i + sliceLength)])
                        .ToArray();
    }
}