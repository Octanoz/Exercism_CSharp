
using ProteinTranslation;

string[] rNA = ["AUGUUUUCU", "AUGUUUUCUUAAAUG"];
string[][] expectedResults =
[
    ["Methionine", "Phenylalanine", "Serine"],
    ["Methionine", "Phenylalanine", "Serine"]
];



for (int i = 0; i < rNA.Length; i++)
{
    Console.WriteLine($"\nFor RNA sequence: {rNA[i]}, the expected result is: {String.Join(", ", expectedResults[i])}");
    Console.WriteLine($"My result: {String.Join(", ", ProteinTranslator.ProteinsTranslator(rNA[i]))}");
    Console.WriteLine($"My result: {String.Join(", ", ProteinTranslator.ProteinsTranslatorLinq(rNA[i]))}");
}