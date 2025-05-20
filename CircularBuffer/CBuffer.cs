public class CBuffer<T>
{
    private T[] buffer;
    private int readPointer;
    private int writePointer;
    private bool isBufferFull;

    public CBuffer(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Capacity must be greater than zero");

        buffer = new T[capacity];
        readPointer = 0;
        writePointer = 0;
        isBufferFull = false;
    }

    public T Read()
    {
        if (isBufferEmpty())
            throw new InvalidOperationException("Buffer is empty, cannot read.");

        T value = buffer[readPointer];
        readPointer = (readPointer + 1) % buffer.Length;
        isBufferFull = false;
        return value;
    }

    public void Write(T value)
    {
        if (isBufferFull)
            throw new InvalidOperationException("Buffer is full, cannot write any more data.");

        buffer[writePointer] = value;
        writePointer = (writePointer + 1) % buffer.Length;

        if (writePointer == readPointer)
            isBufferFull = true;
    }

    public void Overwrite(T value)
    {
        buffer[writePointer] = value;
        writePointer = (writePointer + 1) % buffer.Length;

        if (isBufferFull)
            readPointer = (readPointer + 1) % buffer.Length;
        else isBufferFull = writePointer == readPointer;
    }

    public void Clear()
    {
        readPointer = 0;
        writePointer = 0;
        isBufferFull = false;
    }

    public bool isBufferEmpty() => !isBufferFull && readPointer == writePointer;
}