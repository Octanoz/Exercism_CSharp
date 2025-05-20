using System.Text;

namespace Encoding;

public static class PigLatin
{
    private static readonly string[] VowelSounds = ["xr", "yt", "a", "e", "i", "o", "u"];

    private static readonly string[] ConsonantSounds =
    [
        "ch", "thr", "th", "sch", "rh", "st", "qu",
        "b", "c", "d", "f", "g", "h", "j", "k", "l", "m",
        "n", "p", "r", "s", "t", "v", "w", "x", "y", "z"
    ];

    private static readonly string Qu = "qu";
    private static readonly string Ay = "ay";

    public static string Translate(string word) =>
        String.Join(" ", word.Split().Select(TranslateWord));

    private static string TranslateWord(string word)
    {
        ArgumentException.ThrowIfNullOrEmpty(word);

        if (word.Length == 2 && word[1] == 'y')
        {
            return $"{word[1]}{word[0]}{Ay}";
        }

        if (Array.Exists(VowelSounds, v => word.StartsWith(v)))
        {
            return $"{word}{Ay}";
        }

        string cons = ConsonantSounds.First(c => word.StartsWith(c));

        if (word.IndexOf(Qu) == cons.Length)
        {
            int start = cons.Length + Qu.Length;
            return new(word[start..] + cons + Qu + Ay);
        }

        return new(word[cons.Length..] + cons + Ay);
    }
}