namespace Forth;

public static class ForthMethods
{
    static Stack<int> forthStack = [];
    static Dictionary<string, List<string>> userWords = [];
    static readonly List<string> systemMethods = ["DUP", "DROP", "OVER", "SWAP"];
    static readonly List<string> operators = ["+", "-", "/", "*"];

    public static string Evaluate(string[] instructions)
    {
        forthStack.Clear();

        foreach (string instruction in instructions)
        {
            string[] tokens = instruction.Split();
            if (tokens[0] == ":")
            {
                if (int.TryParse(tokens[1], out _))
                    throw new InvalidOperationException("It is not possible to redefine number values.");

                string methodName = tokens[1].ToLower();
                List<string> userOperations = tokens.Skip(2).SkipLast(1).ToList();
                for (int i = 0; i < userOperations.Count; i++)
                {
                    if (userWords.TryGetValue(userOperations[i], out List<string>? existingList))
                    {
                        userOperations.RemoveAt(i);
                        userOperations.InsertRange(i, existingList);
                    }
                }

                if (!userWords.TryAdd(methodName, userOperations))
                    userWords[methodName] = userOperations;
            }
            else ActionTokens(tokens);
        }

        userWords.Clear();
        return String.Join(" ", forthStack.Reverse());
    }

    private static void ActionTokens(string[] tokens)
    {
        foreach (var token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                forthStack.Push(number);
            }
            else if (userWords.TryGetValue(token.ToLower(), out List<string>? wordParts))
            {
                PerformUserOperation(wordParts);
            }
            else if (systemMethods.Contains(token.ToUpper()))
            {
                RunSystemMethod(token.ToUpper());
            }
            else if (operators.Contains(token))
            {
                PerformOperation(token);
            }
            else throw new InvalidOperationException($"Unknown token in the instructions: {token} {nameof(token)}");
        }
    }

    private static void RunSystemMethod(string token)
    {
        switch (token)
        {
            case "DUP":
                Dup();
                break;
            case "DROP":
                Drop();
                break;
            case "OVER":
                Over();
                break;
            default:
                Swap();
                break;
        }
    }

    private static void PerformOperation(string token)
    {
        if (forthStack.Count < 2)
            throw new InvalidOperationException($"Not enough values on the stack to perform this operation: {token} {nameof(token)}");

        switch (token)
        {
            case "+":
                forthStack.Push(Add(forthStack.Pop(), forthStack.Pop()));
                break;
            case "-":
                forthStack.Push(Subtract(forthStack.Pop(), forthStack.Pop()));
                break;
            case "*":
                forthStack.Push(Multiply(forthStack.Pop(), forthStack.Pop()));
                break;
            case "/":
                forthStack.Push(Divide(forthStack.Pop(), forthStack.Pop()));
                break;
        }
    }

    private static void PerformUserOperation(List<string> wordParts)
    {
        ActionTokens([.. wordParts]);
    }

    private static int Add(int a, int b) => b + a;
    private static int Subtract(int a, int b) => b - a;
    private static int Multiply(int a, int b) => b * a;
    private static int Divide(int a, int b) => a == 0 ? throw new DivideByZeroException() : b / a;

    public static void Dup()
    {
        if (forthStack.Count == 0)
            throw new InvalidOperationException("Not enough values on the stack to perform DUP");

        forthStack.Push(forthStack.Peek());
    }

    public static void Drop()
    {
        if (forthStack.Count == 0)
            throw new InvalidOperationException("Nothing on the stack to drop");

        forthStack.Pop();
    }

    public static void Swap()
    {
        if (forthStack.Count < 2)
            throw new InvalidOperationException("Not enough values on the stack to perform SWAP");

        int temp1 = forthStack.Pop();
        int temp2 = forthStack.Pop();
        forthStack.Push(temp1);
        forthStack.Push(temp2);
    }

    public static void Over()
    {
        if (forthStack.Count < 2)
            throw new InvalidOperationException("There is no second value on the stack so OVER cannot be executed");

        int temp1 = forthStack.Pop();
        int temp2 = forthStack.Peek();
        forthStack.Push(temp1);
        forthStack.Push(temp2);
    }
}