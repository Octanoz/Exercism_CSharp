using TwoBucketNS;

namespace TwoBucketTests;

public class ExercismTests
{
    [Fact]
    public void Measure_using_bucket_one_of_size_3_and_bucket_two_of_size_5_start_with_bucket_one()
    {
        var sut = new TwoBucket(3, 5, Bucket.One);
        var actual = sut.Measure(1);
        Assert.Equal(4, actual.Moves);
        Assert.Equal(5, actual.OtherBucket);
        Assert.Equal(Bucket.One, actual.GoalBucket);
    }
    [Fact]
    public void Measure_using_bucket_one_of_size_3_and_bucket_two_of_size_5_start_with_bucket_two()
    {
        var sut = new TwoBucket(3, 5, Bucket.Two);
        var actual = sut.Measure(1);
        Assert.Equal(8, actual.Moves);
        Assert.Equal(3, actual.OtherBucket);
        Assert.Equal(Bucket.Two, actual.GoalBucket);
    }
    [Fact]
    public void Measure_using_bucket_one_of_size_7_and_bucket_two_of_size_11_start_with_bucket_one()
    {
        var sut = new TwoBucket(7, 11, Bucket.One);
        var actual = sut.Measure(2);
        Assert.Equal(14, actual.Moves);
        Assert.Equal(11, actual.OtherBucket);
        Assert.Equal(Bucket.One, actual.GoalBucket);
    }
    [Fact]
    public void Measure_using_bucket_one_of_size_7_and_bucket_two_of_size_11_start_with_bucket_two()
    {
        var sut = new TwoBucket(7, 11, Bucket.Two);
        var actual = sut.Measure(2);
        Assert.Equal(18, actual.Moves);
        Assert.Equal(7, actual.OtherBucket);
        Assert.Equal(Bucket.Two, actual.GoalBucket);
    }
    [Fact]
    public void Measure_one_step_using_bucket_one_of_size_1_and_bucket_two_of_size_3_start_with_bucket_two()
    {
        var sut = new TwoBucket(1, 3, Bucket.Two);
        var actual = sut.Measure(3);
        Assert.Equal(1, actual.Moves);
        Assert.Equal(0, actual.OtherBucket);
        Assert.Equal(Bucket.Two, actual.GoalBucket);
    }
    [Fact]
    public void Measure_using_bucket_one_of_size_2_and_bucket_two_of_size_3_start_with_bucket_one_and_end_with_bucket_two()
    {
        var sut = new TwoBucket(2, 3, Bucket.One);
        var actual = sut.Measure(3);
        Assert.Equal(2, actual.Moves);
        Assert.Equal(2, actual.OtherBucket);
        Assert.Equal(Bucket.Two, actual.GoalBucket);
    }
    [Fact]
    public void Not_possible_to_reach_the_goal()
    {
        var sut = new TwoBucket(6, 15, Bucket.One);
        Assert.Throws<ArgumentException>(() => sut.Measure(5));
    }
    [Fact]
    public void With_the_same_buckets_but_a_different_goal_then_it_is_possible()
    {
        var sut = new TwoBucket(6, 15, Bucket.One);
        var actual = sut.Measure(9);
        Assert.Equal(10, actual.Moves);
        Assert.Equal(0, actual.OtherBucket);
        Assert.Equal(Bucket.Two, actual.GoalBucket);
    }
    [Fact]
    public void Goal_larger_than_both_buckets_is_impossible()
    {
        var sut = new TwoBucket(5, 7, Bucket.One);
        Assert.Throws<ArgumentException>(() => sut.Measure(8));
    }
}