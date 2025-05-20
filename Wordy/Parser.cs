using System.Text.RegularExpressions;

namespace Wordy;

public static class Parser
{
    public static int Answer(string question)
    {
        var nums = Enumerable.Range(0, 10).Select(n => (char)(n + '0')).ToArray();

        ReadOnlySpan<char> charSpan = question.AsSpan();
        int startIndex = charSpan.IndexOfAny(nums);
        if (startIndex is -1)
            throw new ArgumentException("Did not find any numbers in the question.");

        int endIndex = charSpan.LastIndexOfAny(nums);
        if (endIndex < question.Length - 2)
            throw new ArgumentException($"Unknown operation at the end of the question: <{question[(endIndex + 2)..^1]}>");


        string splitter = @"(plus|minus|multiplied by|divided by)";
        var parts = Regex.Split(question[startIndex..(endIndex + 1)], splitter).Select(s => s.Trim()).ToArray();
        if (!Int32.TryParse(parts[0], out int current))
            throw new ArgumentException("Did not find a valid starting integer.");

        if (startIndex > 0 && charSpan[startIndex - 1] is '-')
            current *= -1;

        Operation operation = new();
        for (int i = 1; i < parts.Length; i++)
        {
            if (Int32.IsOddInteger(i))
            {
                operation = GetOperation(parts[i]);
                continue;
            }

            if (!Int32.TryParse(parts[i], out int next))
                throw new ArgumentException($"Did not find a valid integer.\nInput: [ {parts[i]} ]");

            current = Calculate(current, next, operation);
        }

        return current;
    }

    private static Operation GetOperation(string op) => op switch
    {
        "plus" => Operation.Add,
        "minus" => Operation.Subtract,
        "multiplied by" => Operation.Multiply,
        "divided by" => Operation.Divide,
        _ => throw new ArgumentException($"Invalid operation: {op}")
    };

    private static int Calculate(int current, int next, Operation operation) => operation switch
    {
        Operation.Add => current + next,
        Operation.Subtract => current - next,
        Operation.Multiply => current * next,
        Operation.Divide => current / next,
        _ => throw new ArgumentException($"Invalid operation: {operation}")
    };
}

public enum Operation
{
    Add,
    Subtract,
    Multiply,
    Divide
}
