using ParallelLetterFrequency;

List<string> input = ["BLaaaaa"];

Dictionary<char, int> letterFrequency = ParallelLetterFrequencyMethods.Calculate(input);

foreach (var kvp in letterFrequency)
{
    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
}

Console.WriteLine();
letterFrequency = ParallelLetterFrequencyMethods.CalculateLinq(input);

foreach (var kvp in letterFrequency)
{
    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
}