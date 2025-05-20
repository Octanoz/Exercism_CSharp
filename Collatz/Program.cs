int[] startingNumbers = [12];
int[] expectedResults = [9];

Console.WriteLine();
for (int i = 0; i < startingNumbers.Length; i++)
{
    Console.WriteLine($"Current number: {startingNumbers[i]}");
    Console.WriteLine($"Calculated steps: {Collatz.CollatzConjecture.Steps(startingNumbers[i])}");
    Console.WriteLine($"Expected result: {expectedResults[i]}");
    Console.WriteLine();
}