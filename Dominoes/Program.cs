using Dominoes;

IEnumerable<(int, int)> dominoes = new List<(int, int)>
        {
            (1, 2),
            (2, 3),
            (3, 1),
            (1, 1),
            (2, 2),
            (3, 3)
        };

bool canChain = DominoChain.CanChain(dominoes);

if (canChain)
    Console.WriteLine("Valid Domino Chain.");
else Console.WriteLine("No valid domino chain found.");