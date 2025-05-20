using CollectionExtensions;

int[] nums = [1, 2, 3, 4, 5];
Func<int, bool> isEven = (num) => num % 2 == 0;

int[] evenNums = nums.Keep(isEven).ToArray();
int[] oddNums = nums.Keep(item => !isEven(item)).ToArray();

Console.WriteLine(String.Join(",", evenNums));
Console.WriteLine(String.Join(",", oddNums));
