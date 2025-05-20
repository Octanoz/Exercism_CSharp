using YachtGameMethods;

int[] testDice = [2, 2, 4, 4, 4];
int[] testDice2 = [3, 5, 4, 1, 2];

Console.WriteLine(YachtGame.Score(testDice, YachtCategory.FullHouse));

Console.WriteLine(YachtGame.Score(testDice2, YachtCategory.LittleStraight));