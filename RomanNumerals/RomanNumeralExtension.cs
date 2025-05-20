using System.Text;

namespace RomanNumerals;

public static class RomanNumeralExtension
{
    public static string ConvertToRoman(int arabicNumber)
    {
        StringBuilder sb = new();
        while (arabicNumber > 0)
        {
            foreach (var numeral in NumeralDictionary.RomanNumerals)
            {
                while (arabicNumber >= numeral.Key)
                {
                    sb.Append(numeral.Value);
                    arabicNumber -= numeral.Key;
                }
            }
        }

        return sb.ToString();
    }
}