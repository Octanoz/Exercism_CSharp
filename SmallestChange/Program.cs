using SmallestChange;

int[] coins = [1, 2, 5, 10, 20, 50, 100];
int[] expected = [2, 2, 5, 20, 20, 50, 100, 100, 100, 100, 100, 100, 100, 100, 100];

int[] result = Change.FindFewestCoins(coins, 999);

Console.WriteLine($"Result:   [ {String.Join(", ", result)} ]");
Console.WriteLine($"Expected: [ {String.Join(", ", expected)} ]");