namespace DataStructuresAndAlgorithms.DataStructures;

public class Queue<T>
{
    private T[] _items;
    public int Length { get; private set; }


    public Queue()
    {
        _items = Array.Empty<T>();
        Length = _items.Length;
    }

    public Queue(params T[] items)
    {
        _items = items;
        Length = _items.Length;
    }

    /// <summary>
    /// Add item to queue.
    /// </summary>
    /// <param name="item">Item to be added.</param>
    /// <returns>Array's new length.</returns>
    public int Enqueue(T item)
    {
        int newLength = Length + 1;
        var newArr = new T[newLength];
        newArr[0] = item;
        // now shift
        for (int i = 1; i < Length; i++)
        {
            newArr[i] = _items[i - 1];
        }
        _items = newArr;
        Length++;
        return Length;
    }

    /// <returns>Item being dequeued/removed from queue.</returns>
    public T Dequeue()
    {
        T item = _items[0];
        var newLength = Length - 1;
        // Shift all rtl.
        var newArr = new T[newLength];
        for (int i = 0; i < newLength; i++)
        {
            newArr[i] = _items[i + 1];
        }

        _items = newArr;
        Length--;
        return item;
    }

    public T PeekFirst() => _items[0];
}