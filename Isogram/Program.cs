/*Instructions
Determine if a word or phrase is an isogram.
An isogram (also known as a "non-pattern word") is a word or phrase without a repeating letter, 
however spaces and hyphens are allowed to appear multiple times.

Examples of isograms:

lumberjacks
background
downstream
six-year-old
 */

string word1 = "lumberjacks";
string word2 = "background";
string word3 = "downstream";
string word4 = "six-year-old";
string notIsogram = "whatever";

Console.WriteLine($"{word1} is an isogram: {CheckWord.IsIsogramHash(word1)}");
Console.WriteLine($"{word1} is an isogram: {CheckWord.IsIsogramLinq(word1)}");
Console.WriteLine($"{word1} is an isogram: {CheckWord.IsIsogramBit(word1)}");
Console.WriteLine();
Console.WriteLine($"{word4} is an isogram: {CheckWord.IsIsogramHash(word4)}");
Console.WriteLine($"{word4} is an isogram: {CheckWord.IsIsogramLinq(word4)}");
Console.WriteLine($"{word4} is an isogram: {CheckWord.IsIsogramBit(word4)}");
Console.WriteLine();
Console.WriteLine($"{notIsogram} is an isogram: {CheckWord.IsIsogramHash(notIsogram)}");
Console.WriteLine($"{notIsogram} is an isogram: {CheckWord.IsIsogramLinq(notIsogram)}");
Console.WriteLine($"{notIsogram} is an isogram: {CheckWord.IsIsogramBit(notIsogram)}");
