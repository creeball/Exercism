public class CircularBuffer<T>(int capacity)
{
    private readonly Queue<T> _buffer = new (capacity);

    public T Read()
    {
        if (_buffer.Count == 0)
        {
            throw new InvalidOperationException();
        }
        return _buffer.Dequeue();
    }

    public void Write(T value)
    {
        if (_buffer.Count == capacity)
        {
            throw new InvalidOperationException();
        }
        _buffer.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (_buffer.Count == capacity)
        {
            _buffer.Dequeue();
        }
        _buffer.Enqueue(value);
    }

    public void Clear()
    {
        _buffer.Clear();
    }
}