using System.Text.RegularExpressions;

class Acronymer
{
    public static string MakeShort(string longWord)
    {
        string result = "";

        //Replace all the hyphens (-) and underscores (_) with whitespace (" ")
        //Take the first letter of each element and put it in the return string
        string[] individualWords = longWord.Replace('-', ' ').Replace('_', ' ')
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in individualWords)
            result += word[0];

        return result.ToUpper();
    }

    public static string AbbreviateX(string phrase)
    {
        char[] separators = { ' ', '-', '_' };

        string abbreviation = String.Join("", phrase.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(word => word[0]));

        return abbreviation.ToUpper();
    }

    public static string Abbreviate(string phrase) => String.Join("", phrase.Replace('-', ' ').Replace('_', ' ')
                                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(word => word[0])).ToUpper();

    public static string AbbreviateRegex(string phrase) => Regex.Matches(phrase, @"[a-zA-Z']+")
                                                                .Aggregate("", (output, match) => output + match.Value[0]).ToUpper();
}