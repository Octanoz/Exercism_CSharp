using Games;

string[] mineField =
[
    " * * ",
    "  *  ",
    "  *  ",
    "     "
];

string[] annotatedMineField = Minesweeper.Annotate(mineField);

foreach (var row in annotatedMineField)
{
    Console.WriteLine(row);
}

