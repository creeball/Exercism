using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value) => Value = value;

    public BinarySearchTree(IEnumerable<int> values)
    {
        var enumerable = values as int[] ?? values.ToArray();
        Value = enumerable.First();
        foreach (var value in enumerable.Skip(1)) Add(value);
    }

    public int Value { get; }

    public BinarySearchTree? Left { get; private set; }

    public BinarySearchTree? Right { get; private set; }

    private BinarySearchTree Add(int value)
    {
        if (value <= Value) Left = Add(Left, value);
        else Right = Add(Right, value);
        return this;
    }
    
    private static BinarySearchTree Add(BinarySearchTree? tree, int value) => tree?.Add(value) ?? new BinarySearchTree(value);

    public IEnumerator<int> GetEnumerator()
    {
        if (Left != null)
            foreach (var value in Left) yield return value;
        yield return Value;
        if (Right != null)
            foreach (var value in Right) yield return value;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}