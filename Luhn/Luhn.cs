namespace CCValidator;

public static class Luhn
{
    public static bool IsValid(string number)
    {
        number = number.Replace(" ", "");
        if (number.Length < 2 || !number.All(Char.IsDigit))
            return false;

        int[] validatedNumbers = new int[number.Length];

        bool validate = false;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            if (validate)
            {
                int digit = (number[i] - '0') * 2;
                validatedNumbers[i] = digit > 9 ? digit - 9 : digit;
            }
            else validatedNumbers[i] = number[i] - '0';

            validate = !validate;
        }

        int sum = validatedNumbers.Sum();
        Console.WriteLine(sum);

        return sum % 10 is 0;
    }

    public static bool IsValid2(string number)
    {
        number = number.Replace(" ", "");
        if (number.Length < 2 || !number.All(Char.IsDigit))
            return false;

        int[] validatedNumbers = number.Select(c => c - '0').ToArray();
        for (int i = validatedNumbers.Length - 2; i >= 0; i -= 2)
        {
            validatedNumbers[i] = validatedNumbers[i] > 4 ? validatedNumbers[i] * 2 - 9 : validatedNumbers[i] * 2;
        }

        int sum = validatedNumbers.Sum();
        Console.WriteLine(sum);

        return sum % 10 is 0;
    }

    public static bool IsValidLinq(string number)
    {
        number = number.Replace(" ", "");
        if (number.Length < 2 || !number.All(Char.IsDigit))
            return false;

        return number.Reverse()
                    .Select(c => c - '0')
                    .Select((n, i) => i % 2 is 0 ? n : n * 2)
                    .Select(n => n > 9 ? n - 9 : n)
                    .Sum() % 10 is 0;
    }
}