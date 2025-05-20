namespace Recital;

public class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length is 0)
            return [];

        return subjects.Zip(subjects.Skip(1))
                        .Select(s => $"For want of a {s.First} the {s.Second} was lost.")
                        .Append($"And all for the want of a {subjects.First()}.")
                        .ToArray();
    }
}