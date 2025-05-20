namespace EnumCoding;

[Flags]
public enum Operation
{
    Wink = 1,
    Double_Blink = 1 << 1,
    Close_Your_Eyes = 1 << 2,
    Jump = 1 << 3,
    Reverse = 1 << 4
}

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        List<string> result = [];

        foreach (var operation in Enum.GetValues<Operation>())
        {
            if ((commandValue & (int)operation) == (int)operation)
            {
                result.Add(EnumName(operation));
            }
        }

        if (result.Count > 0 && result[^1] == "reverse")
        {
            result.Reverse();
            return result[1..].ToArray();
        }

        return result.ToArray();
    }

    static string EnumName(Operation operation) => operation.ToString().ToLower().Replace('_', ' ');
}