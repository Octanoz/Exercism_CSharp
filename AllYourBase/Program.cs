using AllYourBase;

int[] num = [3, 46, 60];
// int[] num = [1, 1, 1];

// int[] result = BaseConverter.Rebase(2, num, 10);

// Console.WriteLine(String.Join(" ", result));

int[] resultLinq = BaseConverter.RebaseLinq(97, num, 73);

Console.WriteLine(String.Join(" ", resultLinq));