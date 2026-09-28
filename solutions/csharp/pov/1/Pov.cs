public class Tree(string value, params Tree[] children)
{
    public string Value { get; } = value;
    public List<Tree> Children { get; } = children.ToList();

    public override bool Equals(object? obj) => obj is Tree other && Equals(other);

    private bool Equals(Tree other) =>
        Value == other.Value &&
        Children.OrderBy(c => c.Value).SequenceEqual(other.Children.OrderBy(c => c.Value));

    public override int GetHashCode() =>
        HashCode.Combine(Value, Children.Sum(t => t.GetHashCode()));
}

public static class Pov
{
    public static Tree FromPov(Tree tree, string from)
    {
        Stack<Tree> path = [];
        if (!Search(tree, from, path)) throw new ArgumentException();
        var root = path.Pop();
        var next = root;
        while (path.Count != 0)
        {
            var current = next;
            next = path.Pop();
            next.Children.Remove(current);
            current.Children.Add(next);
        }
        return root;
    }

    private static bool Search(Tree tree, string target, Stack<Tree> path)
    {
        path.Push(tree);
        if (tree.Value == target) return true;
        if (tree.Children.Any(child => Search(child, target, path))) return true;
        path.Pop();
        return false;
    }

    public static IEnumerable<string> PathTo(string from, string to, Tree tree)
    {
        var toRoot = FromPov(tree, from);
        Stack<Tree> path = [];
        if (!Search(toRoot, to, path)) throw new ArgumentException();
        return path.Select(t => t.Value).Reverse();
    }
}