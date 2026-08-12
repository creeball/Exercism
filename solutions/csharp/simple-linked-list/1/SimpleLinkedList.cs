using System.Collections;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private class Node(T value, Node? next = null)
    {
        public T Value { get; } = value;
        public Node? Next { get; } = next;
    }
    private Node? _head;
    public int Count { get; private set; }
    public SimpleLinkedList() { }
    public SimpleLinkedList(IEnumerable<T> values)
    {
        foreach (var value in values) Push(value);
    }
    public void Push(T value)
    {
        _head = _head == null ? new Node(value) : new Node(value, _head);
        Count++;
    }

    public T Pop()
    {
        if (_head == null) throw new InvalidOperationException();
        var node = _head;
        _head = _head.Next;
        Count--;
        return node.Value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (_head == null) yield break;
        var node = _head;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}