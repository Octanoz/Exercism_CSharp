using Rectangles;

string[] input =
[
    "  +-+",
    "  | |",
    "+-+-+",
    "| | |",
    "+-+-+"
];

int result = RectangleCounter.Count(input);

Console.WriteLine(result); // Output: 5
