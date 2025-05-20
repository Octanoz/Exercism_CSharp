namespace Dominoes;

class DominoChain
{
    public static bool CanChainX(IEnumerable<(int, int)> dominoes)
    {
        List<(int, int)> dominoList = dominoes.ToList();

        if (dominoList.Count == 0)
            return true;

        List<(int, int)> chain = new();
        int maxTries = dominoList.Count;

        for (int tries = 0; tries < maxTries; tries++)
        {
            var firstDomino = dominoList[tries];
            chain.Add(firstDomino);
            dominoList.RemoveAt(tries);

            int firstValue = chain.Last().Item1;
            var lastDominoOptions = dominoList.Where(d => d.Item1 == firstValue || d.Item2 == firstValue).ToList();
            (int, int) lastDomino = (0, 0);

            while (lastDominoOptions.Count > 0)
            {
                lastDomino = lastDominoOptions[0];
                lastDominoOptions.RemoveAt(0);
                dominoList.Remove(lastDomino);

                while (dominoList.Count > 0)
                {
                    int lastEnd = chain.Last().Item2;
                    var possibleDomino = dominoList.FirstOrDefault(d => d.Item1 == lastEnd || d.Item2 == lastEnd);

                    if (possibleDomino == default)
                        break;

                    if (possibleDomino.Item1 == lastEnd)
                    {
                        chain.Add((possibleDomino.Item1, possibleDomino.Item2));
                    }
                    else
                    {
                        chain.Add((possibleDomino.Item2, possibleDomino.Item1));
                    }

                    dominoList.Remove(possibleDomino);
                }

                if (lastDominoOptions.Count > 0)
                {
                    dominoList.Clear();
                    dominoList.AddRange(dominoes);
                }
            }

            if (chain.Count == maxTries - 1)
                chain.Add(lastDomino);

            if (chain.First().Item1 == chain.Last().Item2 && dominoList.Count == 0)
                return true;

            chain.Clear();
            dominoList.Clear();
            dominoList.AddRange(dominoes);
        }

        return false;
    }

    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        List<(int, int)> dominoList = dominoes.ToList();

        if (dominoList.Count == 0)
            return true;

        List<(int, int)> chain = new();

        foreach (var domino in dominoes)
        {
            chain.Add(domino);
            dominoList.Remove(domino);

            if (RecursiveCheck(chain, dominoList))
                return true;

            chain.Clear();
            dominoList.Clear();
            dominoList.AddRange(dominoes);
        }

        return false;
    }

    private static bool RecursiveCheck(List<(int, int)> chain, List<(int, int)> remainingDominoes)
    {
        if (!remainingDominoes.Any())
        {
            return chain.First().Item1 == chain.Last().Item2;
        }

        int lastEnd = chain.Last().Item2;

        foreach (var domino in remainingDominoes.ToList())
        {
            if (domino.Item1 == lastEnd)
            {
                chain.Add((domino.Item1, domino.Item2));
                remainingDominoes.Remove(domino);

                if (RecursiveCheck(chain, remainingDominoes))
                    return true;

                chain.RemoveAt(chain.Count - 1);
                remainingDominoes.Add(domino);
            }
            else if (domino.Item2 == lastEnd)
            {
                chain.Add((domino.Item2, domino.Item1));
                remainingDominoes.Remove(domino);

                if (RecursiveCheck(chain, remainingDominoes))
                    return true;

                chain.RemoveAt(chain.Count - 1);
                remainingDominoes.Add(domino);
            }
        }

        return false;
    }
}