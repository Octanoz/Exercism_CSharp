using ListOps;

List<int> list = [2, 5];
int initial = 5;
var function = new Func<int, int, int>((x, y) => x / y);

var result = ListMethods.Foldl(list, initial, function);

Console.WriteLine(result);

List<int> newList = list[1..];

Console.WriteLine(String.Join(", ", newList));
Console.WriteLine(ListMethods.Length(list));

string test = "havanagila";
Console.WriteLine(test[4..]);
Console.WriteLine(test[..^1]);