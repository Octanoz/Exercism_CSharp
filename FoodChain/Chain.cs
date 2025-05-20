namespace FoodChain;

public static class Chain
{
    private static readonly string[] Animals =
    [
        "fly", "spider", "bird", "cat", "dog", "goat", "cow", "horse"
    ];

    private static readonly string[] Actions =
    [
        "I don't know why she swallowed the fly. Perhaps she'll die.",
        "It wriggled and jiggled and tickled inside her.",
        "How absurd to swallow a bird!",
        "Imagine that, to swallow a cat!",
        "What a hog, to swallow a dog!",
        "Just opened her throat and swallowed a goat!",
        "I don't know how she swallowed a cow!",
        "She's dead, of course!"
    ];

    public static string Recite(int verseNumber)
    {
        if (verseNumber is 1 or 8)
        {
            return Intro(verseNumber);
        }

        string spiderLine = Actions[1].Replace("It", " that");

        List<string> lines = [];
        while (verseNumber > 0)
        {
            lines.Add(verseNumber switch
            {
                3 when lines.Count is 0 => $"{Intro(3)[..^1]}{spiderLine}",
                var intro when lines.Count is 0 => Intro(intro),
                1 => Actions[0],
                3 => $"{Reason(3)[..^1]}{spiderLine}",
                _ => Reason(verseNumber)
            });

            verseNumber--;
        }

        return String.Join("\n", lines);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        List<string> verses = [];
        for (int i = startVerse; i <= endVerse; i++)
        {
            verses.Add(Recite(i));
        }

        return String.Join("\n\n", verses);
    }

    private static string Reason(int index) =>
        $"She swallowed the {Animals[index - 1]} to catch the {Animals[index - 2]}.";

    private static string Intro(int index)
    {
        string introLine = $"I know an old lady who swallowed a {Animals[index - 1]}.\n{Actions[index - 1]}";
        return index is 1 or 8 ? introLine : $"{introLine}\n{Reason(index)}";
    }

}
