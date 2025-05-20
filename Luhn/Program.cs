using CCValidator;

string[] creditcardNumbers = ["4539 3195 0343 6467", "8273 1232 7352 0569", "055 444 285", "095 245 88", "234 567 891 234", "0000 0", "9999999999 9999999999 9999999999 9999999999"];

for (int i = 0; i < creditcardNumbers.Length; i++)
{
    Console.WriteLine($"Is [{creditcardNumbers[i]}] a valid credit card number? [{Luhn.IsValidLinq(creditcardNumbers[i])}]\n");
}