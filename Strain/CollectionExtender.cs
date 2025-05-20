namespace CollectionExtensions;

public static class CollectionExtender
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => collection.Where(predicate);

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate) => collection.Keep(item => !predicate(item));
}