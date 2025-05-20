using Series;

string numbers = "49142";

string[] slices = StringSlicer.SlicesLinq(numbers, 4);

foreach (var slice in slices)
    Console.WriteLine(slice);