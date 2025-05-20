using Accumulate;

int[] nums = [1, 2, 3, 4, 5];

var result = AccumulateExtensions.Accumulate(nums, x => x * x);
Console.WriteLine(string.Join(", ", result));

