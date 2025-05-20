namespace Rhymes;

public static class HouseRhyme
{
    static readonly string[] Characters =
        [
            "malt",
            "rat",
            "cat",
            "dog",
            "cow with the crumpled horn",
            "maiden all forlorn",
            "man all tattered and torn",
            "priest all shaven and shorn",
            "rooster that crowed in the morn",
            "farmer sowing his corn",
            "horse and the hound and the horn"
        ];
    static readonly string[] Actions =
        [
            "lay in",
            "ate",
            "killed",
            "worried",
            "tossed",
            "milked",
            "kissed",
            "married",
            "woke",
            "kept",
            "belonged to"
        ];

    public static string Recite(int verseNumber)
    {
        if (verseNumber is 1)
            return "This is the house that Jack built.";

        return $"This is the {Characters[verseNumber - 2]}" +

        Enumerable.Range(0, verseNumber - 2)
                    .Reverse()
                    .Aggregate("", (acc, i) => acc + $"\nthat {Actions[i + 1]} the {Characters[i]}") +

        "\nthat lay in the house that Jack built.";
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var verses = Enumerable.Range(startVerse, endVerse - startVerse + 1).Select(i => Recite(i));

        return String.Join("\n\n", verses);
    }

    public static string ReciteAlt(int verseNumber)
    {
        if (verseNumber is 1)
            return "This is the house that Jack built.";

        string firstLine = $"This is the {Characters[verseNumber - 2]}\n";

        var verses = Characters.Take(verseNumber - 2)
                                    .Zip(Actions.Skip(1), (c, a) => $"that {a} the {c}\n")
                                    .Reverse();

        string lastLine = "that lay in the house that Jack built.";

        return $"{firstLine}{String.Join("", verses)}{lastLine}";
    }
}