namespace Pythagorean;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (int a = 1; a < sum / 3; a++)
        {
            for (int b = a + 1; b < sum / 2; b++)
            {
                int c = sum - (a + b);

                if (a * a + b * b == c * c)
                    yield return (a, b, c);
            }
        }
    }

    public static IEnumerable<(int a, int b, int c)> TripletsWithSumLinq(int sum)
    {
        return Enumerable.Range(1, sum / 3)
                        .SelectMany(a => Enumerable.Range(a + 1, sum / 2 - a)
                            .Select(b => (a, b, c: sum - a - b)))
                        .Where(tuple => tuple.a * tuple.a + tuple.b * tuple.b == tuple.c * tuple.c);
    }

}