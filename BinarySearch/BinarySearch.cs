namespace SearchMethods;

public static class BinarySearch
{
    public static int Find(Span<int> input, int target)
    {
        var (left, right) = (0, input.Length - 1);
        var targetFound = (-10, -10);

        while (left <= right)
        {
            int middle = (left + right) / 2;

            (left, right) = (input[middle] - target) switch
            {
                > 0 => (left, middle - 1),
                < 0 => (middle + 1, right),
                _ => targetFound
            };

            if ((left, right) == targetFound)
                return middle;
        }

        return -1;
    }
}