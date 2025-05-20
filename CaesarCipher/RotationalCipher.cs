using System.Text;

public static class RotationalCipher
{
    //This version can only correctly (de)cypher using positive shiftkeys
    public static string Rotate(string text, int shiftKey)
    {
        //Make sure shiftKey is within the range (0 - 26)
        shiftKey %= 26;

        StringBuilder rotatedString = new();

        foreach (char c in text)
        {
            if (Char.IsLetter(c))
            {
                //Offset by 65 (A) or 97 (a)
                char offset = Char.IsUpper(c) ? 'A' : 'a';
                char rotatedChar = (char)(((c + shiftKey) - offset) % 26 + offset);

                rotatedString.Append(rotatedChar);
            }
            else rotatedString.Append(c);
        }

        return rotatedString.ToString();
    }

    //This version can also take negative keys
    /* public static string Rotate2(string text, int shiftKey)
    {
        StringBuilder rotatedString = new();

        foreach (char c in text)
        {
            if (Char.IsLetter(c))
            {
                char offset = Char.IsUpper(c) ? 'A' : 'a';
                char rotatedChar = (char)(((c + shiftKey - offset + 26) % 26) + offset);

                rotatedString.Append(rotatedChar);
            }
            else rotatedString.Append(c);
        }

        return rotatedString.ToString();
    } */
}