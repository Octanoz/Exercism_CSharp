namespace Armstrong;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int length = number.ToString().Length;

        int originalNumber = number;
        int powerNumber = 0;

        while (number is not 0)
        {
            int currentNumber = number % 10;
            powerNumber += (int)Math.Pow(currentNumber, length);
            number /= 10;
        }

        return originalNumber == powerNumber;
    }

    public static bool IsArmstrongNumberLinq(int number)
    {
        var digits = number.ToString().Select(n => n - '0');
        return number == digits.Select(n => (int)Math.Pow(n, digits.Count())).Sum();
    }
}