using System.Text.RegularExpressions;

string[] phoneNumbers =
[
    "+1 (613)-995-0253",
    "613-995-0253",
    "1 613 995 0253",
    "613.995.0253",
    "22234567890",
    "321234567890",
    "223 456   7890   "
];

foreach (var number in phoneNumbers)
{
    Console.WriteLine(CleanPhoneNumber(number));
}

string CleanPhoneNumber(string phoneNumber)
{
    string pattern = @"^\+?1?\s?\(?([2-9]\d{2})\)?[-\.]?\s*([2-9]\d{2})[-\.]?\s*(\d{4})\s*$";

    //match will have one group for the result of the entire matched expression and a group for every capture group (.*) in the expression
    var match = Regex.Match(phoneNumber, pattern);
    if (match.Groups.Count == 4)
    {
        var result = match.Groups[1].Value + match.Groups[2].Value + match.Groups[3].Value;
        var result2 = match.Groups.Values
                                        .Skip(1)
                                        .Select(m => m.Value)
                                        .Aggregate((a, b) => a + b)
                                        .ToString();

        var result3 = String.Join("", match.Groups.Values.Skip(1));

        return result3;
    }
    else return "invalid number";
}