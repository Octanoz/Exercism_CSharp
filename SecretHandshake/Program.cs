using EnumCoding;

for (int i = 0; i < 32; i++)
{
    string[] result = SecretHandshake.Commands(i);

    Console.WriteLine($"Commands for {i} -> {String.Join(" | ", result)}");
}