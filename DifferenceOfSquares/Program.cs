int[] numbers = [3, 6, 8, 10];
int[] expectedResult = [22, 350, 1092, 2640];

for (int i = 0; i < numbers.Length; i++)
{
    int result = DifferenceSum(numbers[i], out int squareOfSum, out int sumOfSquares);
    Console.WriteLine($"\nFor natural numbers up to and including {numbers[i]} the difference between the square of the sum ({squareOfSum}) and the sum of the squares ({sumOfSquares}) is {expectedResult[i]}");
    Console.WriteLine($"My result: {result}");
    Console.WriteLine($"With single line LINQ: {DifferenceSumLinq(numbers[i])}");
}

int DifferenceSum(int number, out int squareOfSum, out int sumOfSquares)
{
    squareOfSum = (int)Math.Pow(Enumerable.Range(1, number).Sum(), 2);
    sumOfSquares = Enumerable.Range(1, number).Select(n => n * n).Sum();

    return squareOfSum - sumOfSquares;
}

int DifferenceSumLinq(int number) => Square(Enumerable.Range(1, number).Sum()) - Enumerable.Range(1, number).Sum(Square);

static int Square(int n) => n * n;

