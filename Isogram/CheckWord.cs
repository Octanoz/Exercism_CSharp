class CheckWord
{
    public static bool IsIsogramHash(string word)
    {
        HashSet<char> letters = new();

        foreach (var character in word)
        {
            if (char.IsLetter(character) && !letters.Add(character))
                return false;
        }

        return true;
    }

    public static bool IsIsogramDict(string word)
    {
        word = word.ToLower();
        Dictionary<char, int> lettersCount = new();

        foreach (var character in word)
        {
            if (char.IsLetter(character))
            {
                if (lettersCount.ContainsKey(character))
                    return false;
                else lettersCount[character] = 1;
            }
        }

        return true;
    }

    public static bool IsIsogramLinq(string word)
    {
        List<char> letters = word.ToLower().Where(char.IsLetter).ToList();

        return letters.Distinct().Count() == letters.Count;
    }

    public static bool IsIsogramBit(string word)
    {
        word = word.ToLower();
        int alphabet = (1 << 26) - 1;

        foreach (var character in word)
        {
            if (char.IsLetter(character))
            {
                int bitN = character - 'a';
                int binCharacter = (1 << bitN);

                if ((alphabet & binCharacter) == 0)
                    return false;
                else alphabet ^= binCharacter;
            }
        }

        return true;
    }
}