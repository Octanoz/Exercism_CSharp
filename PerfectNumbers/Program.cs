using PerfectNumbers;

int[] sampleNumbers = [6, 28, 12, 24, 8, 15, 1];
Classification[] expectedResults =
[Classification.Perfect, Classification.Perfect, Classification.Abundant, Classification.Abundant, Classification.Deficient, Classification.Deficient, Classification.Deficient];

for (int i = 0; i < sampleNumbers.Length; i++)
{
    Console.WriteLine($"Current number: {sampleNumbers[i]}");
    Console.WriteLine(Solution.ClassifyLinq(sampleNumbers[i]));
    Console.WriteLine($"Expected result: {expectedResults[i]}");
    Console.WriteLine();
}