namespace TwoBucketNS;

public class TwoBucketResult
{
    public int Moves { get; set; }
    public Bucket GoalBucket { get; set; }
    public int OtherBucket { get; set; }
}
public class TwoBucket
{
    private readonly Bucket startBucket;
    public int CapOne { get; init; }
    public int CapTwo { get; init; }
    public TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket)
    {
        (CapOne, CapTwo, this.startBucket) = (bucketOne, bucketTwo, startBucket);
    }

    public TwoBucketResult Measure(int goal)
    {
        HashSet<(int, int)> visited = [(0, CapTwo), (CapOne, 0), (0, 0)];

        (int, int) startState = startBucket == Bucket.One ? (CapOne, 0) : (0, CapTwo);

        return Loop(startState, 1) ?? throw new ArgumentException("Cannot measure with the given buckets");

        TwoBucketResult Loop((int one, int two) buckets, int actions)
        {
            if (buckets.one == goal || buckets.two == goal)
            {
                return (buckets.one == goal) switch
                {
                    true => new() { Moves = actions, GoalBucket = Bucket.One, OtherBucket = buckets.two },
                    false => new() { Moves = actions, GoalBucket = Bucket.Two, OtherBucket = buckets.one }
                };
            }

            List<TwoBucketResult> results = [];

            int pourOneToTwo = Math.Min(buckets.one, CapTwo - buckets.two);
            int pourTwoToOne = Math.Min(buckets.two, CapOne - buckets.one);

            List<((int, int), int)> nextStates =
            [
                ((CapOne, buckets.two), actions + 1),
                ((buckets.one, CapTwo), actions + 1),
                ((0, buckets.two), actions + 1),
                ((buckets.one, 0), actions + 1),
                ((buckets.one - pourOneToTwo, buckets.two + pourOneToTwo), actions + 1),
                ((buckets.one + pourTwoToOne, buckets.two - pourTwoToOne), actions + 1)
            ];

            foreach (var (nextState, nextActions) in nextStates)
            {
                if (visited.Add(nextState))
                {
                    var result = Loop(nextState, nextActions);
                    if (result is not null)
                    {
                        results.Add(result);
                    }
                }
            }

            return results.OrderBy(r => r.Moves).FirstOrDefault()!;
        }
    }
}