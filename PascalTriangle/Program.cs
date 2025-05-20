using PascalTriangle;

int rows = 5;

var result = TriangleBuilder.Calculate(rows);

foreach (var row in result)
{
    Console.WriteLine(new string(' ', --rows) + string.Join(" ", row));
}