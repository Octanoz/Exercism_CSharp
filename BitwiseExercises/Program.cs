using System.Collections;
using BitwiseExercises;
/* Iterative
For any number, we can check whether its ‘i’th bit is 0(OFF) or 1(ON) by bitwise ANDing it with “2^i” (2 raise to i).

1) Let us take number 'NUM' and we want to check whether it's 0th bit is ON or OFF    
    bit = 2 ^ 0 (0th bit)
    if  NUM & bit >= 1 means 0th bit is ON else 0th bit is OFF

2) Similarly if we want to check whether 5th bit is ON or OFF    
    bit = 2 ^ 5 (5th bit)
    if NUM & bit >= 1 means its 5th bit is ON else 5th bit is OFF.

Let us take unsigned integer (32 bit), which consist of 0-31 bits. 
To print binary representation of unsigned integer, start from 31th bit, 
check whether 31th bit is ON or OFF, if it is ON print “1” else print “0”. 
Now check whether 30th bit is ON or OFF, if it is ON print “1” else print “0”, 
do this for all bits from 31 to 0, finally we will get binary representation of number.
 */

/* GFG.Bin(10);
Console.WriteLine();
GFG.Bin(4); */

/* Recursive
For a recursive solution you would have to follow these steps:

step 1) if NUM > 1
    a) push NUM on stack
    b) recursively call function with 'NUM / 2'
step 2)
    a) pop NUM from stack, divide it by 2 and print it's remainder.
 */

/* GFG.BinRecursive(7);
Console.WriteLine();
GFG.BinRecursive(4); */

/* Recursive using Bitwise operator
step 1: Check n > 0
step 2: Right shift the number by 1 bit and recursive function call
step 3: Print the bits of number
 */

/* Console.WriteLine();
GFG.BinRecursiveBitwise(7);
Console.WriteLine();
GFG.BinRecursiveBitwise(4); */

/* BitArray
We can use the BitArray.Length property in the for loop to represent the whole binary number
or we can set the size of the representation to 8 for a single byte
 */

/* int n = 156;
int m = -156;

BitArray b = new(new int[] { n });
BitArray b1 = new(new int[] { m });

Console.WriteLine($"Binary of 156: \t\t{GFG.GetBits(b)}");
Console.WriteLine($"Binary of -156: \t{GFG.GetBits(b1)}"); */

//* Demonstration of Bitwise complement and shift left until 0

/* int a = 127;
int b = ~a;

int c = a + b;
int d = b + 1;

Console.WriteLine($"a = {a} = \t\t\t{Convert.ToString(a, 2).PadLeft(10, '0')}");
Console.WriteLine($"b is a complement = {b} = \t{Convert.ToString(b, 2)[22..]}");
Console.WriteLine($"a + b = {a + b} = \t\t\t{Convert.ToString(c, 2)[22..]}");
Console.WriteLine($"b + 1 = {b + 1} = \t\t\t{Convert.ToString(d, 2)[22..]}");
Console.WriteLine();

while (a != 0)
{
    a <<= 1;
    Console.WriteLine($"{a,11} = {Convert.ToString(a, 2).PadLeft(32, '0')}");
    Thread.Sleep(500);
} */

//* Bit shift left and right demo

/* Console.WriteLine("\n");
byte x = byte.MaxValue;

Console.WriteLine($"Bit shift right from {x}");
Console.WriteLine("========================");
Console.Write($"{x} ");
Console.WriteLine($"\t{Convert.ToString(x, 2).PadLeft(8, '0')}");
while (x > 0)
{
    x = (byte)(x >> 1);
    Console.Write($"{x} ");
    Console.WriteLine($"\t{Convert.ToString(x, 2).PadLeft(8, '0')}");
}

Console.WriteLine();

byte y = 7;
Console.WriteLine($"Bit shift left from {y}");
Console.WriteLine($"=====================");
Console.Write($"{y} ");
Console.WriteLine($"\t{Convert.ToString(y, 2).PadLeft(8, '0')}");

while (y != 0)
{
    y = (byte)(y << 1);
    Console.Write($"{y} ");
    Console.WriteLine($"\t{Convert.ToString(y, 2).PadLeft(8, '0')}");
} */

//* Flipping the value of 2 int variables using XOR

int x = 85;
int y = 93;

Console.WriteLine($"Swap x ({x}) and y ({y})");
Console.WriteLine($"x = \t\t{x} = \t{Convert.ToString(x, 2).PadLeft(8, '0')}");
Console.WriteLine($"y = \t\t{y} = \t{Convert.ToString(y, 2).PadLeft(8, '0')}");
x ^= y;
Console.WriteLine($"x = x ^ y = \t{x} = \t{Convert.ToString(x, 2).PadLeft(8, '0')}");
y = x ^ y;
Console.WriteLine($"y = x ^ y = \t{y} = \t{Convert.ToString(y, 2).PadLeft(8, '0')}");
x ^= y;
Console.WriteLine($"x = x ^ y = \t{x} = \t{Convert.ToString(x, 2).PadLeft(8, '0')}");
Console.WriteLine();
Console.WriteLine($"x is {x} and y is {y}");