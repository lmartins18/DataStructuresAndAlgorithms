namespace DataStructuresAndAlgorithms.DataStructures;

public class Stack<T>
{
    // We can use a dynamic array to hold items, since they work identically.
    private DynamicArray<T> _items;
    public int Length { get; private set; }

    public Stack(params T[] items)
    {
        _items = new DynamicArray<T>(items);
        Length = _items.Length;
    }

    /// <summary>
    /// <para>Pops (removes) the last element in the list.</para>
    /// </summary>
    /// <returns>The item popped.</returns>
    /// <exception cref="InvalidOperationException">If trying to pop empty array.</exception>
    public T Pop()
    {
        if (Length == 0) throw new InvalidOperationException("Cannot pop empty stack.");

        T item = _items[^1];
        // We use the remove method to allow the array to resize if needed.
        _items.RemoveLast();
        Length--;
        return item;
    }

    /// <summary>
    /// Pushes (adds) an element to the end of the array.
    /// </summary>
    public void Push(T item)
    {
        _items.Add(item);
        Length++;
    }

    /// <summary>
    /// Looks at the last element in the stack without removing it.
    /// </summary>
    /// <returns>The last element of the stack.</returns>
    public T Peek() => _items[^1];
}