using SaddlePoints;
using static SaddlePoints.TreeHouseSiteFinder;

int[,] matrix =
{
    { 8, 7, 9 },
    { 6, 7, 6 },
    { 3, 2, 5 }
}; // bottom-right or (3,3) is the correct answer

Console.WriteLine("Matrix 1:");
foreach (var coord in Calculate(matrix))
{
    Console.WriteLine(coord);
}

int[,] matrix2 =
{
    { 6, 7, 8 },
    { 5, 5, 5 },
    { 7, 5, 6 }
}; // The entire middle row are all 'saddlepoints'

Console.WriteLine("\nMatrix 2:");
foreach (var coord in Calculate(matrix2))
{
    Console.WriteLine(coord);
}
