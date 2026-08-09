public enum Bucket
{
    One,
    Two
}

public record struct TheBucket(int Capacity, int Current = 0)
{
    public TheBucket Full() => this with { Current = Capacity };
    public TheBucket Clear() => this with { Current = 0 };

    public static (TheBucket, TheBucket) Pull(TheBucket bucketOne, TheBucket bucketTwo)
    {
        int available = bucketTwo.Capacity - bucketTwo.Current;
        if (bucketOne.Current > available)
        {
            bucketOne.Current -= available;
            bucketTwo = bucketTwo.Full();
        }
        else
        {
            bucketTwo.Current += bucketOne.Current;
            bucketOne = bucketOne.Clear();
        }
        return (bucketOne, bucketTwo);
    }
    public bool IsFull() => Current == Capacity;
    public bool IsEmpty() => Current == 0;
}

public class TwoBucketResult
{
    public int Moves { get; set; }
    public Bucket GoalBucket { get; set; }
    public int OtherBucket { get; set; }
}

public class TwoBucket
{
    private readonly TheBucket _bucketOne;
    private readonly TheBucket _bucketTwo;
    private readonly Bucket _startBucket;

    public TwoBucket(int bucketOne, int bucketTwo, Bucket startBucket)
    {
        _bucketOne = new TheBucket(bucketOne);
        _bucketTwo = new TheBucket(bucketTwo);
        _startBucket = startBucket;
        if (startBucket == Bucket.One) _bucketOne = _bucketOne.Full();
        else _bucketTwo = _bucketTwo.Full();
    }

    public TwoBucketResult Measure(int goal)
    {
        Queue<(int Moves, (TheBucket BucketOne, TheBucket BucketTwo) Buckets)> queue = [];
        HashSet<(TheBucket, TheBucket)> visited = [(_bucketOne, _bucketTwo)];
        queue.Enqueue((1, (_bucketOne, _bucketTwo)));
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.Buckets.BucketOne.Current == goal)
                return new TwoBucketResult
                {
                    Moves = current.Moves,
                    GoalBucket = Bucket.One,
                    OtherBucket = current.Buckets.BucketTwo.Current
                };
            if (current.Buckets.BucketTwo.Current == goal)
                return new TwoBucketResult
                {
                    Moves = current.Moves,
                    GoalBucket = Bucket.Two,
                    OtherBucket = current.Buckets.BucketOne.Current
                };
            foreach (var next in GetNext(current.Buckets))
            {
                if (visited.Contains(next) || !Check(next)) continue;
                visited.Add(next);
                queue.Enqueue((current.Moves + 1, next));
            }
        }
        throw new ArgumentException();
    }
    
    private IEnumerable<(TheBucket, TheBucket)> GetNext((TheBucket bucketOne, TheBucket bucketTwo) buckets)
    {
        yield return (buckets.bucketOne.Clear(), buckets.bucketTwo);
        yield return (buckets.bucketOne, buckets.bucketTwo.Clear());
        yield return (buckets.bucketOne.Full(), buckets.bucketTwo);
        yield return (buckets.bucketOne, buckets.bucketTwo.Full());
        yield return (TheBucket.Pull(buckets.bucketOne, buckets.bucketTwo));
        (TheBucket bucketTwo, TheBucket bucketOne) temp = TheBucket.Pull(buckets.bucketTwo, buckets.bucketOne);
        yield return (temp.bucketOne, temp.bucketTwo);
    }

    private bool Check((TheBucket bucketOne, TheBucket bucketTwo) buckets) =>
        _startBucket switch
        {
            Bucket.One => !(buckets.bucketOne.IsEmpty() && buckets.bucketTwo.IsFull()),
            Bucket.Two => !(buckets.bucketOne.IsFull() && buckets.bucketTwo.IsEmpty()),
            _ => true
        };
}