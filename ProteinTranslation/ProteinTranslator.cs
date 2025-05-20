namespace ProteinTranslation;

public static class ProteinTranslator
{
    static readonly string[] stopProteins = ["UAA", "UAG", "UGA"];
    static readonly Dictionary<string, string> codonTranslations = new()
    {
        ["AUG"] = "Methionine",
        ["UUU"] = "Phenylalanine",
        ["UUC"] = "Phenylalanine",
        ["UUA"] = "Leucine",
        ["UUG"] = "Leucine",
        ["UCU"] = "Serine",
        ["UCC"] = "Serine",
        ["UCA"] = "Serine",
        ["UCG"] = "Serine",
        ["UAU"] = "Tyrosine",
        ["UAC"] = "Tyrosine",
        ["UGU"] = "Cysteine",
        ["UGC"] = "Cysteine",
        ["UGG"] = "Tryptophan"
    };

    public static List<string> ProteinsTranslator(string rNAString)
    {
        List<string> result = [];
        for (int i = 0; i < rNAString.Length; i += 3)
        {
            string codon = rNAString[i..(i + 3)];
            if (stopProteins.Contains(codon))
            {
                return result;
            }

            result.Add(codonTranslations[codon]);
        }

        return result;
    }

    public static string[] ProteinsTranslatorLinq(string rNAString)
    {
        return rNAString.Chunk(3)
                        .Select(CodonTranslator)
                        .TakeWhile(protein => protein != "Stop")
                        .ToArray();
    }

    private static string CodonTranslator(char[] codon)
    {
        return String.Join("", codon) switch
        {
            "AUG" => "Methionine",
            "UGG" => "Tryptophan",
            "UGU" or "UGC" => "Cysteine",
            "UUA" or "UUG" => "Leucine",
            "UUU" or "UUC" => "Phenylalanine",
            "UAU" or "UAC" => "Tyrosine",
            "UAA" or "UAG" or "UGA" => "Stop",
            "UCU" or "UCC" or "UCA" or "UCG" => "Serine",
            _ => throw new ArgumentException("Unknown codon string", nameof(codon))
        };
    }
}