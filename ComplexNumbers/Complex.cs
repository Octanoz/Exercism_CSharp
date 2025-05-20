namespace Complex;

public struct ComplexNumber(double real, double imaginary)
{
    public readonly double Real() => real;

    public readonly double Imaginary() => imaginary;

    public readonly ComplexNumber Mul(ComplexNumber other)
    {
        double realMultiplied = Real() * other.Real() - Imaginary() * other.Imaginary();
        double imaginaryMultiplied = Imaginary() * other.Real() + Real() * other.Imaginary();

        return new(realMultiplied, imaginaryMultiplied);
    }

    public readonly ComplexNumber Mul(double other) => Mul(new ComplexNumber(other, 0.0));

    public readonly ComplexNumber Add(ComplexNumber other) =>
        new(Real() + other.Real(), Imaginary() + other.Imaginary());

    public readonly ComplexNumber Add(double other) => new(Real() + other, Imaginary());


    public readonly ComplexNumber Sub(ComplexNumber other) =>
        new(Real() - other.Real(), Imaginary() - other.Imaginary());

    public readonly ComplexNumber Div(ComplexNumber other)
    {
        double realDivided;
        double imaginaryDivided = 0.0;

        switch (other)
        {
            case ComplexNumber c when c.Real() == 0 && c.Imaginary() == 0:
                throw new DivideByZeroException("Division by zero is not allowed.");

            case ComplexNumber c when c.Real() == 0:
                realDivided = Imaginary() / c.Imaginary();
                break;

            case ComplexNumber c when c.Imaginary() == 0:
                realDivided = Real() / c.Real();
                break;

            default:
                double denominator = other.Real() * other.Real() + other.Imaginary() * other.Imaginary();
                realDivided = (Real() * other.Real() + Imaginary() * other.Imaginary()) / denominator;
                imaginaryDivided = (Imaginary() * other.Real() - Real() * other.Imaginary()) / denominator;
                break;
        }

        return new(realDivided, imaginaryDivided);
    }

    public readonly ComplexNumber Div(double other) => other is not 0
                                            ? new(Real() / other, Imaginary() / other)
                                            : throw new DivideByZeroException("Division by zero is not allowed.");


    public readonly double Abs() =>
        Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imaginary, 2));

    public readonly ComplexNumber Conjugate() => new(Real(), -Imaginary());

    public readonly ComplexNumber Exp()
    {
        double realExponented = Math.Exp(Real()) * Math.Cos(Imaginary());
        double imaginaryExponented = Math.Exp(Real()) * Math.Sin(Imaginary());

        return new(realExponented, imaginaryExponented);
    }
}