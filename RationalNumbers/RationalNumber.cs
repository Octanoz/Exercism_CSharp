namespace RationalNumbers;

public struct RationalNumber
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominator cannot be zero.");

        var gcd = GCD(numerator, denominator);
        numerator /= gcd;
        denominator /= gcd;

        // Ensure the denominator is positive
        if (denominator < 0)
        {
            numerator *= -1;
            denominator *= -1;
        }

        Numerator = numerator;
        Denominator = denominator;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator;
        int denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator;
        int denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        int numerator = r1.Numerator * r2.Numerator;
        int denominator = r1.Denominator * r2.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        if (r2.Numerator == 0)
            throw new DivideByZeroException("Cannot divide by zero.");

        int numerator = r1.Numerator * r2.Denominator;
        int denominator = r1.Denominator * r2.Numerator;
        return new RationalNumber(numerator, denominator);
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator));
    }

    public RationalNumber Reduce()
    {
        var gcd = GCD(Numerator, Denominator);
        return new RationalNumber(Numerator / gcd, Denominator / gcd);
    }

    public RationalNumber Exprational(int power) => power switch
    {
        > 0 => new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denominator, power)),
        _ => new RationalNumber((int)Math.Pow(Denominator, -power), (int)Math.Pow(Numerator, -power))
    };

    public static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return Math.Pow(realNumber, (double)r.Numerator / r.Denominator);
    }
}
