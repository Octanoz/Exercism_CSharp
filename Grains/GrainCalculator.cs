using System.Numerics;

class GrainCalculator
{
    //Do not set higher than 64 as the bitwise calculation and ulong will not be able to handle it
    const int MaxSquares = 64;
    public static ulong Square(int n)
    {
        if (n >= 1 && n <= MaxSquares)
            return 1UL << (n - 1);
        else throw new ArgumentOutOfRangeException(nameof(n), $"Can only calculate for values between 1 and {MaxSquares}");
    }

    public static ulong TotalXX() => ~0UL;

    public static ulong Total() => (ulong)((BigInteger.One << MaxSquares) - 1);
    public static ulong TotalX() => Enumerable.Range(1, 64).Aggregate(0UL, (sum, n) => sum + Square(n));
}