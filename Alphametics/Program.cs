using Alphametics;

string[][] numbers =
[
    ["send", "more", "money"],
    ["wrong", "wrong", "right"],
    ["letters", "alphabet", "scrabble"]
];

for (int i = 0; i < numbers.Length; i++)
{
    int[] output = Assigner.AssignNumbers(numbers[i][0], numbers[i][1], numbers[i][2]);
    Assigner.ResetCollections();
    if (output is not [])
    {
        // var result = output.ToList();
        // result.ForEach(Console.WriteLine);
        Console.WriteLine(FormatResult(numbers[i], output));
    }
    else Console.WriteLine("Empty result");
    Console.WriteLine();
}

static string FormatResult(string[] sequences, int[] output)
{
    int width = sequences.Max(s => s.Length);

    return
    $"""
    {output[0],12}
    {output[1],12}
    {new string('-', width),12} +
    {output[2],12}
    """;
}
