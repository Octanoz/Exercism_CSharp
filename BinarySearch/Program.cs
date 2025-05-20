using SearchMethods;

int[] nums = [4, 8, 12, 16, 23, 28, 32];
Random random = new();

for (int i = 0; i < 5; i++)
{
    int target = nums[random.Next(0, nums.Length)];

    Console.WriteLine($"Array: [{String.Join(", ", nums)}]");
    Console.WriteLine($"Index of {target} in array: {Array.IndexOf(nums, target)}");
    Console.WriteLine($"Binary Search result: {BinarySearch.Find(nums, target)}");
    Console.WriteLine("\n=========================\n");
}