public class CBuffer2<T>
{
    T[] buffer;
    int tail = 0;
    int head = 0;

    public CBuffer2(int capacity)
    {
        buffer = new T[capacity];
    }
    public T Read()
    {
        if (isEmpty)
            throw new InvalidOperationException("Buffer is empty, nothing to read");

        return buffer[Wrap(tail++)];
    }
    public void Write(T value)
    {
        if (isFull)
            throw new InvalidOperationException("Buffer is full, cannot write any more data");

        buffer[Wrap(head++)] = value;
    }
    public void Overwrite(T value)
    {
        if (isFull)
            tail++;
        Write(value);
    }
    public void Clear()
    {
        tail = head;
    }
    private int Length => head - tail;
    public bool isEmpty => tail == head;

    public bool isFull => buffer.Length == Length;
    private int Wrap(int n) => n % buffer.Length;
}