using TwoBucketNS;

TwoBucket twoB = new(3, 5, Bucket.One);

TwoBucketResult result = twoB.Measure(1);

Console.WriteLine($"Moves: {result.Moves}\nBucket with goal liters: {result.GoalBucket}\nLiters left in other bucket: {result.OtherBucket}");

public enum Bucket
{
    One,
    Two
}
