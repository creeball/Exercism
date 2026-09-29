public record Tree(char Value, Tree? Left, Tree? Right);

public static class Satellite
{
    public static Tree? TreeFromTraversals(char[] preOrder, char[] inOrder)
    {
        if (preOrder.Length != inOrder.Length || preOrder.Length != preOrder.Distinct().Count())
            throw new ArgumentException();
        if (preOrder is []) return null;
        var value = preOrder[0];
        var index = inOrder.IndexOf(value);
        if (index == -1 || inOrder.LastIndexOf(value) != index) throw new ArgumentException();
        var leftPreOrder = preOrder[1..(index + 1)];
        var rightPreOrder = preOrder[(index + 1)..];
        var leftInOrder = inOrder[..index];
        var rightInOrder = inOrder[(index + 1)..];
        return new Tree(value,
            TreeFromTraversals(leftPreOrder, leftInOrder),
            TreeFromTraversals(rightPreOrder, rightInOrder));
    }
}
