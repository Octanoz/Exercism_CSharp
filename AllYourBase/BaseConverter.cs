namespace AllYourBase;

public static class BaseConverter
{
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase)
    {
        if (inputBase < 2 || outputBase < 2)
            throw new ArgumentException("Input and output base cannot be less than 2");

        int originalNumber = 0;

        Array.Reverse(inputDigits);

        for (int i = 0; i < inputDigits.Length; i++)
        {
            if (inputDigits[i] < 0)
                throw new ArgumentException("Negative digit found in input array");

            originalNumber += inputDigits[i] * (int)Math.Pow(inputBase, i);
        }

        List<int> result = [];

        while (originalNumber > 0)
        {
            result.Insert(0, originalNumber % outputBase);
            originalNumber /= outputBase;
        }

        return [.. result];
    }

    public static int[] RebaseLinq(int inputBase, int[] inputDigits, int outputBase)
    {
        if (!ValidInput(inputBase, inputDigits, outputBase, out string message))
            throw new ArgumentException(message);

        int baseTen = inputDigits.Reverse()
                                    .Select((digit, index) => digit * (int)Math.Pow(inputBase, index))
                                    .Sum();

        List<int> result = [];
        while (baseTen is not 0)
        {
            result = [baseTen % outputBase, .. result];
            baseTen /= outputBase;
        }

        return result.Count is 0 ? [0] : [.. result];
    }

    private static bool ValidInput(int inputBase, int[] inputDigits, int outputBase, out string message)
    {
        message = "";
        if (inputBase < 2 || outputBase < 2)
        {
            message += "Input and output base cannot be less than 2. ";
        }
        if (Array.Exists(inputDigits, d => d < 0))
        {
            message += "Negative digit found in input array. ";
        }
        if (Array.Exists(inputDigits, d => d >= inputBase))
        {
            message += "Digits in the input array have to be lower in value than the input base.";
        }

        return message == "";
    }
}