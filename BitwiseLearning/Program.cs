/* string[] binary =
{
    "0000","0001","0010","0011","0100","0101",
    "0110","0111","1000","1001","1010",
    "1011","1100","1101","1110","1111"
};

int a = 3; //0011
int b = 6; //0110

//Bitwise OR
int c = a | b; //0111 -- 7

//Bitwise AND
int d = a & b; //0010 -- 2

//Bitwise XOR
int e = a ^ b; //0101 -- 5

//Bitwise NOT
int f = (~a & b) | (a & ~b);

int g = ~a & 0x0f;

Console.WriteLine($"a = \t\t{binary[a]}");
Console.WriteLine($"b = \t\t{binary[b]}");

Console.WriteLine();

Console.WriteLine($"a|b (OR)= \t{binary[c]}");
Console.WriteLine($"a&b (AND)= \t{binary[d]}");
Console.WriteLine($"a^b (XOR)= \t{binary[e]}");
Console.WriteLine($"~a & b|a&~b = \t{binary[f]}");
Console.WriteLine($"~a (NOT)= \t{binary[g]}"); */

int num1 = 4; //0100
int num2 = -8; //1000

Console.WriteLine($"Using numbers {num1} and {num2}");
Console.WriteLine($"Bitwise AND: {num1 & num2}");
Console.WriteLine($"Bitwise OR: {num1 | num2}");
Console.WriteLine($"Bitwise XOR: {num1 ^ num2}");
Console.WriteLine($"Bitwise NOT ({num1}): {~num1}");
Console.WriteLine();
Console.WriteLine($"Bitwise left shift ({num1}): {num1 << 2}");
Console.WriteLine($"Bitwise right shift ({num1}): {num1 >> 2}");
Console.WriteLine($"Bitwise unsigned right shift ({num1}): {num1 >>> 2}");