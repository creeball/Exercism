using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    public BinarySearchTree(int value) => Value = value;

    public BinarySearchTree(IEnumerable<int> values)
    {
        var enumerable = values as int[] ?? values.ToArray();
        Value = enumerable.First();
        foreach (var value in enumerable.Skip(1))
        {
            Add(value);
        }
    }

    public int Value
    {
        get;
        set;
    }

    public BinarySearchTree? Left
    {
        get;
        private set;
    }

    public BinarySearchTree? Right
    {
        get;
        private set;
    }

    public BinarySearchTree Add(int value)
    {
        if (value <= Value)
        {
            if (Left == null) Left = new BinarySearchTree(value);
            else Left.Add(value);
        }
        else
        {
            if (Right == null) Right = new BinarySearchTree(value);
            else Right.Add(value);
        }
        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (Left != null)
        {
            foreach (var value in Left)
            {
                yield return value;
            }
        }
        yield return Value;
        if (Right != null)
        {
            foreach (var value in Right)
            {
                yield return value;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}