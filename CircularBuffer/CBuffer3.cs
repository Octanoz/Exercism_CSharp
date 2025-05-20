
public class CBuffer3<T> : Queue<T>
{
    public int Capacity { get; }
    public CBuffer3(int capacity)
    {
        Capacity = capacity;
    }
    public T Read()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("buffer is empty.");
        }
        var item = Dequeue();
        return item;
    }
    public void Write(T value)
    {
        if (Count == Capacity)
        {
            throw new InvalidOperationException("buffer is full.");
        }
        Enqueue(value);
    }
    public void Overwrite(T value)
    {
        if (Count == Capacity)
        {
            Dequeue();
        }
        Enqueue(value);
    }
    /* because I inherit  Queue<T>, So reuse Clear() of Queue<T> . It will work well. */
    //public void Clear() { }
}