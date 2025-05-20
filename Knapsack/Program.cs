using Knap;

(int weight, int value)[] items =
[
    (weight: 5, value: 10),
    (weight: 4, value: 40),
    (weight: 6, value: 30),
    (weight: 4, value: 50)
];

//21
(int weight, int value)[] items2 =
[
    (weight: 2, value: 5),
    (weight: 2, value: 5),
    (weight: 2, value: 5),
    (weight: 2, value: 5),
    (weight: 10, value: 21)
];

//900
(int weight, int value)[] items3 =
[
    (weight: 25, value: 350),
    (weight: 35, value: 400),
    (weight: 45, value: 450),
    (weight: 5, value: 20),
    (weight: 25, value: 70),
    (weight: 3, value: 8),
    (weight: 2, value: 5),
    (weight: 2, value: 5)
];

//1458
(int weight, int value)[] items4 =
[
    (weight: 70, value: 135),
    (weight: 73, value: 139),
    (weight: 77, value: 149),
    (weight: 80, value: 150),
    (weight: 82, value: 156),
    (weight: 87, value: 163),
    (weight: 90, value: 173),
    (weight: 94, value: 184),
    (weight: 98, value: 192),
    (weight: 106, value: 201),
    (weight: 110, value: 210),
    (weight: 113, value: 214),
    (weight: 115, value: 221),
    (weight: 118, value: 229),
    (weight: 120, value: 240)
];

(int weight, int value)[][] itemCollections = [items, items2, items3, items4];
int[] targetWeights = [10, 10, 104, 750];

for (int i = 0; i < 4; i++)
{
    Console.WriteLine(Knapsack.MaximumValue3(targetWeights[i], itemCollections[i]));
}

