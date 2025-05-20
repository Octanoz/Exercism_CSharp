using Pythagorean;

// int[] testNumbers = [12, 1000];

for (int i = 1; i <= 1000; i++)
{
    var triplets = PythagoreanTriplet.TripletsWithSumLinq(i);

    if (triplets.Any())
    {
        Console.WriteLine($"Triplets with sum {i}:");
        foreach (var triplet in triplets)
        {
            Console.WriteLine(triplet);
        }
        Console.WriteLine("===============\n");
    }
}