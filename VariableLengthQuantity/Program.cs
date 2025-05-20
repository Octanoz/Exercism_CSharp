/* Instructions
---------------
Implement variable length quantity encoding and decoding.

In short, the goal of this encoding is to encode integer values in a way that would save bytes.
Only the first 7 bits of each byte are significant (right-justified; sort of like an ASCII byte).
So, if you have a 32-bit value, you have to unpack it into a series of 7-bit bytes.
Of course, you will have a variable number of bytes depending upon your integer.
To indicate which is the last byte of the series, you leave bit #7 clear. In all of the preceding bytes, you set bit #7.

So, if an integer is between 0-127, it can be represented as one byte.
Although VLQ can deal with numbers of arbitrary sizes, for this exercise we will restrict ourselves to only numbers that fit in a 32-bit unsigned integer.
Here are examples of integers as 32-bit values, and the variable length quantities that they translate to:

 NUMBER        VARIABLE QUANTITY
00000000              00
00000040              40
0000007F              7F
00000080             81 00
00002000             C0 00
00003FFF             FF 7F
00004000           81 80 00
00100000           C0 80 00
001FFFFF           FF FF 7F
00200000          81 80 80 00
08000000          C0 80 80 00
0FFFFFFF          FF FF FF 7F

This exercise requires you to use bitwise operations.
For more information, see https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators
 */

uint[] numbers = { 0, 0x40, 0x7F, 0x80, 0x2000, 0x3FFF, 0x4000, 0x100000, 0x1FFFFF, 0x200000, 0x8000000, 0xFFFFFFF };
//decimal numbers = 0, 64, 127, 128, 8192, 16383, 16384, 1048576, 2097151, 2097152, 134217728, 268435455

uint[] testNumbers = { 192, 0 };

uint[] encoded = VLQ.Encode(numbers);
uint[] encoded2 = VLQ.Encode2(numbers);
uint[] decoded = VLQ.Decode(encoded);

Console.WriteLine("Encoded:");
// Console.WriteLine(string.Join(" ", encoded));

foreach (var number in encoded)
    Console.Write($"{number} ");
Console.WriteLine();
Console.WriteLine(string.Join(" ", encoded2));
// Console.WriteLine("Decoded:");
// Console.WriteLine(string.Join(" ", decoded));