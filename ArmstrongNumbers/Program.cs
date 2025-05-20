using Armstrong;

int[] inputs = [9, 10, 153, 190];
bool[] expectedResults = [true, false, true, false];

for (int i = 0; i < inputs.Length; i++)
{
    bool result = ArmstrongNumbers.IsArmstrongNumberLinq(inputs[i]);

    Console.WriteLine($"Input: {inputs[i]}\n Found correct result: {expectedResults[i] == result}\n");
}