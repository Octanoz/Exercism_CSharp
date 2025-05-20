
namespace AnagramMethods;

public class Anagram(string baseWord)
{
    readonly string lowerBase = baseWord.ToLower();
    readonly char[] originalWord = baseWord.ToLower().Order().ToArray();

    public string[] FindAnagrams(string[] potentialMatches)
    {
        string[] anagrams = [];

        foreach (var word in potentialMatches)
        {
            string lowerWord = word.ToLower();
            if (lowerWord != lowerBase && lowerWord.IsAnagramOf(originalWord))
            {
                anagrams = [.. anagrams, word];
            }
        }

        return anagrams;
    }
}

public static class StringExtensions
{
    public static bool IsAnagramOf(this string word, char[] characters) => characters.SequenceEqual(word.Order());
}