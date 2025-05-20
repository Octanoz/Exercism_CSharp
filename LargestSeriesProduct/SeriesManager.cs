using System.Runtime.Intrinsics.X86;

namespace LargestSeriesProduct;

public static class SeriesManager
{
    public static long GetLargestProduct(string digits, int span)
    {
        return Enumerable.Range(0, digits.Length - span + 1)
                                    .Select(i => digits[i..(i + span)])
                                    .Select(substring => substring
                                        .Select(c => c - '0')
                                        .Aggregate((a, b) => a * b))
                                    .Max();
    }

    private static long SeriesProduct(string number) => number.Select(c => c - '0')
                                                                .Aggregate((a, b) => a * b);
}