using System.Net;
using System.Text;

int[] nums = [1, 4, 6, 7, 34, 30, 3, 21, 10, 105];

foreach (var num in nums)
{
    Console.WriteLine($"\nResult for {num}: ");
    Console.WriteLine(PlingerLinq(num));
}

string Plinger(int number)
{
    Dictionary<int, string> storedResponses = new()
    {
        [3] = "Pling",
        [5] = "Plang",
        [7] = "Plong"
    };

    string result = "";
    foreach (var key in storedResponses.Keys)
    {
        if (number % key == 0)
            result += storedResponses[key];
    }

    return result == "" ? $"{number}" : result;
}

string Plonger(int number)
{
    List<(int factor, string response, string divisibleFactor)> storedResponses =
    [
        (3, "Pling", "divisible by 3"),
        (5, "Plang", "divisible by 5"),
        (7, "Plong", "divisible by 7")
    ];

    StringBuilder sb = new();
    foreach (var (factor, response, divisibleFactor) in storedResponses)
    {
        if (number % factor == 0)
        {
            sb.Append(response);
            Console.WriteLine(divisibleFactor);
        }
    }

    return sb.Length == 0 ? $"{number}" : sb.ToString();
}

string Planger(int number)
{
    List<(int factor, string response, string divisibleFactor)> storedResponses =
    [
        (3, "Pling", "divisible by 3"),
        (5, "Plang", "divisible by 5"),
        (7, "Plong", "divisible by 7")
    ];

    Span<char> result = stackalloc char[storedResponses.Count * 10];
    int index = 0;
    foreach (var (factor, response, divisibleFactor) in storedResponses)
    {
        if (number % factor == 0)
        {
            int len = response.Length;
            int nextEmpty = index * len;
            response.AsSpan().CopyTo(result[nextEmpty..(nextEmpty + len)]);
            Console.WriteLine(divisibleFactor);
            index++;
        }
    }

    return result[0] == '\0' ? $"{number}" : result[..result.IndexOf('\0')].ToString();
}

string PlingerLinq(int number)
{
    List<(int factor, string response, string divisibleFactor)> storedResponses =
    [
        (3, "Pling", "divisible by 3"),
        (5, "Plang", "divisible by 5"),
        (7, "Plong", "divisible by 7")
    ];

    return String.Join("", storedResponses.Where(sr => number % sr.factor == 0)
                                                            .Select(sr => sr.response)
                                                            .DefaultIfEmpty($"{number}"));
}
