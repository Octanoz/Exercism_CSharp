namespace ETL;

public class DictionaryConverter
{
    // This method takes a dictionary with scores as keys and an array of letters as values,
    // and converts it to a new dictionary where each letter is a key and its score is the value.
    public static Dictionary<string, int> ConvertToDictionary(Dictionary<int, string[]> input)
    {
        var keys = input.Keys;
        List<(string Key, int Value)> kvpList = [];
        foreach (var key in keys)
        {
            kvpList.AddRange(input[key].Select(c => (c.ToLower(), key)));
        }

        return kvpList.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    public static Dictionary<string, int> ShortConvert(Dictionary<int, string[]> input) =>
        input.SelectMany(kvp => kvp.Value.Select(c => (Key: c.ToLower(), Value: kvp.Key)))
             .ToDictionary(elem => elem.Key, elem => elem.Value);
}