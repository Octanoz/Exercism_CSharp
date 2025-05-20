namespace ScrabbleScore;

public static class ScrabbleCalculator
{
    public static int WordScore(string input) => input.ToLower()
                                                        .Select(letter => LetterScore(letter))
                                                        .Aggregate(0, (a, b) => a + b);

    private static int LetterScore(char letter)
    {
        return letter switch
        {
            'f' or 'h' or 'v' or 'w' or 'y' => 4,
            'b' or 'c' or 'm' or 'p' => 3,
            'q' or 'z' => 10,
            'j' or 'x' => 8,
            'd' or 'g' => 2,
            'k' => 5,
            _ => 1
        };
    }

    public static int Score(string input)
    {
        return input.ToLower().Select(letter => letter switch
        {
            'f' or 'h' or 'v' or 'w' or 'y' => 4,
            'b' or 'c' or 'm' or 'p' => 3,
            'q' or 'z' => 10,
            'j' or 'x' => 8,
            'd' or 'g' => 2,
            'k' => 5,
            _ => 1
        }).Sum();
    }
}