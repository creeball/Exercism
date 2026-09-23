public class CustomSet(params IEnumerable<int> values)
{
    private readonly HashSet<int> _values = values.ToHashSet();

    public CustomSet Add(int value) => new(_values.Append(value));

    public bool Empty() => _values.Count == 0;

    public bool Contains(int value) => _values.Contains(value);

    public bool Subset(CustomSet right) => _values.IsSubsetOf(right._values);

    public bool Disjoint(CustomSet right) => !_values.Overlaps(right._values);

    public CustomSet Intersection(CustomSet right) => new(_values.Intersect(right._values));

    public CustomSet Difference(CustomSet right) => new(_values.Except(right._values));

    public CustomSet Union(CustomSet right) => new(_values.Union(right._values));

    public override bool Equals(object? obj) => obj is CustomSet other && _values.SetEquals(other._values);

    public override int GetHashCode() => _values.Aggregate(0, HashCode.Combine);
}