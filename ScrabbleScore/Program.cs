using ScrabbleScore;

string testString = "cabbage";
int expectedResult = 14;

Console.WriteLine($"\nFor the string: {testString}, the expected result is: {expectedResult}");
Console.WriteLine($"My result: {ScrabbleCalculator.WordScore(testString)}\n");
Console.WriteLine($"Alternative method: {ScrabbleCalculator.Score(testString)}\n");