namespace ScaleGenerator;

public static class Scale
{
    private static readonly (string, string)[] notes =
    [
        ("A", "A"),
        ("A#", "Bb"),
        ("B", "B"),
        ("C", "C"),
        ("C#", "Db"),
        ("D", "D"),
        ("D#", "Eb"),
        ("E", "E"),
        ("F", "F"),
        ("F#", "Gb"),
        ("G", "G"),
        ("G#", "Ab")
    ];

    private static readonly string[] sharpInitializers =
    [
        "C", "G", "D", "A", "E", "B", "F#", "a", "e", "b", "f#", "c#", "g#", "d#"
    ];

    public static string[] Chromatic(string tonic)
    {
        int index = Array.FindIndex(notes, n => n.Item1.Equals(tonic, StringComparison.OrdinalIgnoreCase)
                                             || n.Item2.Equals(tonic, StringComparison.OrdinalIgnoreCase));

        var newScale = notes[index..].Concat(notes[..index]);
        return sharpInitializers.Contains(tonic) switch
        {
            true => newScale.Select(n => n.Item1).ToArray(),
            false => newScale.Select(n => n.Item2).ToArray()
        };
    }

    public static string[] Interval(string tonic, string pattern)
    {
        var notesSpan = sharpInitializers.Contains(tonic)
                      ? notes.Select(n => n.Item1).ToArray()
                      : notes.Select(n => n.Item2).ToArray();

        if (Char.IsLower(tonic[0]))
        {
            tonic = tonic.Length switch
            {
                1 => tonic.ToUpper(),
                _ => $"{Char.ToUpper(tonic[0])}{tonic[1]}"
            };
        }

        int index = Array.FindIndex(notes, n => n.Item1.Equals(tonic)
                                             || n.Item2.Equals(tonic));

        List<string> result = [tonic];
        return pattern.Aggregate((index, result), (acc, c) =>
        {
            acc.index += c switch
            {
                'm' => 1,
                'M' => 2,
                'A' => 3,
                _ => throw new ArgumentException($"Invalid interval pattern character: [{c}]")
            };

            acc.result.Add(notesSpan[acc.index % 12]);

            return (acc.index, acc.result);
        }).result.ToArray();
    }
}