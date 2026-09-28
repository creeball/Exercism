public class BinTree(int value, BinTree? left, BinTree? right)
{
    public int Value { get; } = value;
    public BinTree? Left { get; } = left;
    public BinTree? Right { get; } = right;

    public override bool Equals(object? obj) =>
        obj is BinTree other &&
        Equals(other);

    private bool Equals(BinTree other) =>
        Value == other.Value &&
        Equals(Left, other.Left) &&
        Equals(Right, other.Right);

    public override int GetHashCode() => HashCode.Combine(Value, Left, Right);
}

public class Zipper
{
    private int _value;
    private Zipper? _left;
    private Zipper? _right;
    private Zipper? _up;
    public int Value() => _value;

    public Zipper SetValue(int newValue)
    {
        _value = newValue;
        return this;
    }

    public Zipper SetLeft(BinTree? binTree)
    {
        _left = binTree == null ? null : FromTree(binTree);
        _left?._up = this;
        return this;
    }

    public Zipper SetRight(BinTree? binTree) 
    {
        _right = binTree == null ? null : FromTree(binTree);
        _right?._up = this;
        return this;
    }

    public Zipper? Left() => _left;

    public Zipper? Right() => _right;

    public Zipper? Up() => _up;

    private BinTree ToTreeNode() => new(Value(), Left()?.ToTreeNode(), Right()?.ToTreeNode());
    public BinTree ToTree()
    {
        Zipper head = this;
        while (head._up != null) head = head._up;
        return head.ToTreeNode();
    }

    public static Zipper FromTree(BinTree tree)
    {
        Zipper zipper = new();
        zipper.SetValue(tree.Value);
        zipper.SetLeft(tree.Left);
        zipper.SetRight(tree.Right);
        return zipper;
    }

    public override bool Equals(object? obj) =>
        obj is Zipper other &&
        Equals(other);

    private bool Equals(Zipper other) =>
        _value == other._value &&
        Equals(_left, other._left) &&
        Equals(_right, other._right);

    public override int GetHashCode() => HashCode.Combine(Value(), Left(), Right());
}