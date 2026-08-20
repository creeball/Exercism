public class Deque<T>
{
    private record Node(T Value)
    {
        public Node? Next;
        public Node? Previous;
    }
    
    private Node? _head;
    private Node? _tail;

    public void Push(T value)
    {
        var node = new Node(value);
        if (_head == null || _tail == null) 
        {
            _head = node;
            _tail = node;
            return;
        }
        _tail.Next = node;
        node.Previous = _tail;
        _tail = node;
    }

    public T? Pop()
    {
        if (_tail == null) return default;
        var node = _tail;
        _tail = _tail.Previous;
        if (_tail == null) _head = null;
        else _tail.Next = null;
        return node.Value;
    }

    public void Unshift(T value)
    {
        var node = new Node(value);
        if (_head == null || _tail == null)
        {
            _head = node;
            _tail = node;
            return;
        }
        _head.Previous = node;
        node.Next = _head;
        _head = node;
    }

    public T? Shift()
    {
        if (_head == null) return default;
        var node = _head;
        _head = _head.Next;
        if (_head == null) _tail = null;
        else _head.Previous = null;
        return node.Value;
    }
}
