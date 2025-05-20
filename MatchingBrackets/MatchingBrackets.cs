public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        int straightCount = 0, curlyCount = 0, roundCount = 0;

        foreach (char c in input)
        {
            switch (c)
            {
                case '[':
                    straightCount++;
                    break;
                case ']':
                    if (straightCount == 0)
                        return false;
                    else
                        straightCount--;
                    break;
                case '{':
                    curlyCount++;
                    break;
                case '}':
                    if (curlyCount == 0)
                        return false;
                    else
                        curlyCount--;
                    break;
                case '(':
                    roundCount++;
                    break;
                case ')':
                    if (roundCount == 0)
                        return false;
                    else
                        roundCount--;
                    break;
            }
        }

        return (straightCount == 0 && curlyCount == 0 && roundCount == 0);
    }

    public static bool IsPairedExpression(string input)
    {
        int straightCount = 0, curlyCount = 0, roundCount = 0;

        foreach (char c in input)
        {
            straightCount += c switch
            {
                '[' => 1,
                ']' => -1,
                _ => 0
            };

            curlyCount += c switch
            {
                '{' => 1,
                '}' => -1,
                _ => 0
            };

            roundCount += c switch
            {
                '(' => 1,
                ')' => -1,
                _ => 0
            };
        }

        return straightCount + curlyCount + roundCount == 0;
    }


    public static bool IsPairedLINQ(string input)
    {
        int straightOpening = input.Where(c => c == '[').Count();
        int straightClosing = input.Where(c => c == ']').Count();
        int curlyOpening = input.Where(c => c == '{').Count();
        int curlyClosing = input.Where(c => c == '}').Count();
        int roundOpening = input.Where(c => c == '(').Count();
        int roundClosing = input.Where(c => c == ')').Count();

        return ((straightOpening - straightClosing) == 0 && (curlyOpening - curlyClosing) == 0 && (roundOpening - roundClosing) == 0);
    }

    public static bool IsPairedLINQ2(string input)
    {
        char[] openingBrackets = new[] { '[', '{', '(' };
        char[] closingBrackets = new[] { ']', '}', ')' };

        var bracketValues = input.Select(c => openingBrackets.Contains(c) ? 1 : closingBrackets.Contains(c) ? -1 : 0);

        return bracketValues.Sum() == 0;
    }

    public static bool IsPairedStack(string input)
    {
        Stack<char> brackets = new();
        char[] openingBrackets = new[] { '[', '{', '(' };
        char[] closingBrackets = new[] { ']', '}', ')' };

        foreach (char c in input)
        {
            if (openingBrackets.Contains(c))
                brackets.Push(c);
            else if (closingBrackets.Contains(c))
            {
                if (brackets.Count == 0)
                    return false;

                char openingBracket = brackets.Pop();

                if (c == ']' && openingBracket != '[' ||
                    c == '}' && openingBracket != '{' ||
                    c == ')' && openingBracket != '(')
                {
                    return false;
                }
            }
        }

        return brackets.Count == 0;
    }

    public static bool AreBracketsValid(string input)
    {
        Stack<char> brackets = new Stack<char>();
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        foreach (char c in input)
        {
            if (bracketPairs.ContainsKey(c))
            {
                brackets.Push(c);
            }
            else if (bracketPairs.ContainsValue(c))
            {
                if (brackets.Count == 0 || c != bracketPairs[brackets.Peek()])
                {
                    return false;
                }
                brackets.Pop();
            }
        }

        return brackets.Count == 0;
    }
}