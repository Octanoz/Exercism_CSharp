namespace ListOps;

public static class ListMethods
{
    public static int Length<T>(List<T> input)
    {
        if (input.Count == 0)
            return 0;

        return 1 + Length(input[1..]);
    }

    public static List<T> Reverse<T>(List<T> input)
    {
        if (input.Count == 0)
            return [];

        List<T> result = Reverse(input[1..]);
        result.Add(input[0]);

        return result;
    }

    public static List<TOut> Map<TIn, TOut>(List<TIn> input, Func<TIn, TOut> map)
    {
        if (Length(input) == 0)
            return [];

        List<TOut> result = Map(input[1..], map);
        result.Add(map(input[0]));

        return result;
    }

    public static List<T> Filter<T>(List<T> input, Func<T, bool> predicate)
    {
        if (Length(input) == 0)
            return [];

        List<T> result = Filter(input[1..], predicate);

        if (predicate(input[0]))
            result.Add(input[0]);

        return result;
    }

    public static TOut Foldl<TIn, TOut>(List<TIn> input, TOut start, Func<TOut, TIn, TOut> func, int index = 0)
    {
        if (index >= Length(input))
            return start;

        TOut newValue = func(start, input[0]);
        return Foldl(input, newValue, func, index + 1);
    }

    public static TOut Foldr<TIn, TOut>(List<TIn> input, TOut start, Func<TIn, TOut, TOut> func)
    {
        if (Length(input) == 0)
            return start;

        TOut newValue = func(input[^1], start);
        return Foldr(input[..^1], start, func);
    }

    public static List<T> Concat<T>(List<List<T>> input)
    {
        List<T> result = [];
        foreach (var item in input)
            Append(result, item);

        return result;
    }

    public static List<T> Append<T>(List<T> left, List<T> right)
    {
        int len1 = Length(left);
        int len2 = Length(right);
        int len = len1 + len2;

        for (int i = len1; i < len; i++)
        {
            left.Add(right[i - len1]);
        }

        return left;
    }
}