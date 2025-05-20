class Solution
{
    public static bool IsPangramDistinct(string testString)
    {
        return testString.ToLower().Distinct().Count(char.IsLetter) == 26;
    }

    public static bool IsPangramX(string testString)
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        return alphabet.All(testString.ToLower().Contains);
    }
    public static bool UsedWholeAlphabet(string testString)
    {
        testString = testString.ToLower();
        List<char> alphabet = new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        foreach (var letter in testString)
        {
            if (alphabet.Contains(letter))
                alphabet.Remove(letter);
        }

        return !alphabet.Any();
    }

    public static bool IsPangramMask(string testString)
    {
        testString = testString.ToLower();
        int mask = 0;
        int alphabetRange = 'z' - 'a' + 1;

        foreach (var character in testString)
        {
            if (char.IsLetter(character))
            {
                int bitN = character - 'a';
                mask |= 1 << bitN;
            }
        }

        return mask == (1 << alphabetRange) - 1;
    }

    public static bool IsPangramMaskInverted(string testString)
    {
        testString = testString.ToLower();
        int alphabet = (1 << 26) - 1;

        foreach (var character in testString)
        {
            if (char.IsLetter(character))
            {
                int bitN = character - 'a';
                alphabet &= ~(1 << bitN);
            }

            if (alphabet == 0)
                return true;
        }

        return false;
    }

    public static bool IsPangramHash(string testString)
    {
        HashSet<char> letters = new(testString.ToLower());
        string alphabet = "abcdefghijklmnopqrstuvwxyz";

        return letters.IsSupersetOf(alphabet);
    }

    [Flags]
    enum Letter
    {
        a = 1,
        b = 1 << 1,
        c = 1 << 2,
        d = 1 << 3,
        e = 1 << 4,
        f = 1 << 5,
        g = 1 << 6,
        h = 1 << 7,
        i = 1 << 8,
        j = 1 << 9,
        k = 1 << 10,
        l = 1 << 11,
        m = 1 << 12,
        n = 1 << 13,
        o = 1 << 14,
        p = 1 << 15,
        q = 1 << 16,
        r = 1 << 17,
        s = 1 << 18,
        t = 1 << 19,
        u = 1 << 20,
        v = 1 << 21,
        w = 1 << 22,
        x = 1 << 23,
        y = 1 << 24,
        z = 1 << 25
    }

    public static bool IsPangramEnum(string testString)
    {
        Letter alphabet = Letter.a | Letter.b | Letter.c | Letter.d | Letter.e | Letter.f | Letter.g |
                            Letter.h | Letter.i | Letter.j | Letter.k | Letter.l | Letter.m | Letter.n |
                            Letter.o | Letter.p | Letter.q | Letter.r | Letter.s | Letter.t | Letter.u |
                            Letter.v | Letter.w | Letter.x | Letter.y | Letter.z;

        foreach (var character in testString.ToLower())
        {
            int index = character - 'a';
            alphabet &= ~(Letter)(1 << index);
        }

        return alphabet == 0;
    }

}