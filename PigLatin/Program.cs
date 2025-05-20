using Encoding;

string[] testStrings = ["apple", "xray", "yttria", "pig", "chair", "stand", "rhythm", "my", "xenon", "yellow", "quick fast run"];

foreach (var str in testStrings)
{
    Console.WriteLine(PigLatin.Translate(str));
}