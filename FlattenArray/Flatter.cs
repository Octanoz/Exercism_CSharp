namespace FlattenArray;

public static class Flatter
{
    public static IEnumerable<object> Flatten2(IEnumerable<object?> input)
    {
        List<object> result = [];
        foreach (var mystery in input)
        {
            Flattener(mystery);
        }

        return result;

        void Flattener(object? something)
        {
            switch (something)
            {
                case IEnumerable<object?> arr:
                    foreach (object? thing in arr)
                        Flattener(thing);
                    break;
                case object:
                    result.Add(something);
                    break;
                default: break;
            }
        }
    }

    public static IEnumerable<object> Flatten(IEnumerable<object?> input) => input.SelectMany(Flattener2);

    private static IEnumerable<object> Flattener2(object? something) => something switch
    {
        IEnumerable<object?> arr => arr.SelectMany(Flattener2),
        object obj => [obj],
        _ => []
    };
}
