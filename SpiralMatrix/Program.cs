/* Instructions
----------------
Given the size, return a square matrix of numbers in spiral order.

The matrix should be filled with natural numbers, starting from 1 in the top-left corner, increasing in an inward, clockwise spiral order, like these examples:

Examples

Spiral matrix of size 3
1 2 3
8 9 4
7 6 5

Spiral matrix of size 4
 1  2  3  4
12 13 14  5
11 16 15  6
10  9  8  7
 */

/*
0,0 0,1 0,2
1,0 1,1 1,2
2,0 2,1 2,2

3, 2, 2, 1, 1

0,0 0,1 0,2 0,3
1,0 1,1 1,2 1,3
2,0 2,1 2,2 2,3
3,0 3,1 3,2 3,3

4, 3, 3, 2, 2, 1, 1

0,0 0,1 0,2 0,3 0,4
1,0 1,1 1,2 1,3 1,4
2,0 2,1 2,2 2,3 2,4
3,0 3,1 3,2 3,3 3,4
4,0 4,1 4,2 4,3 4,4

5, 4, 4, 3, 3, 2, 2, 1, 1
 */

//SpiralMatrix.GetMatrix(3);

/* int[,] matrix = new int[3, 3];
int num = 1;

for (int i = 0; i < 3; i++)
{
    matrix[0, i] = num++;
} */

int[,] matrixTrial = new int[3, 3]
{
    { 1, 2, 3 },
    { 8, 9, 4 },
    { 7, 6, 5 }
};

SpiralMatrix.ShowArrayInfo(matrixTrial);

int size = 4;
int[,] matrix = SpiralMatrix.GetMatrixClean2(size);

for (int i = 0; i < size; i++)
{
    for (int j = 0; j < size; j++)
    {
        Console.Write($"{matrix[i, j],3}");
    }

    Console.WriteLine();
}