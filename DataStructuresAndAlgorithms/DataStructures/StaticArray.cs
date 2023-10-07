namespace DataStructuresAndAlgorithms.DataStructures;

/// <summary>
/// <para>This is a class to implement a static array in C#.</para>
/// <para>Following pure concepts, this can obviously lead to memory leaks and data loss when inserting/deleting.</para>
/// </summary>
public class StaticArray<T>
{
    private readonly T[] _items;
    public int Length { get; private set; }

    public StaticArray(params T[] items)
    {
        _items = items;
        Length = _items.Length;
    }

    public StaticArray(int length)
    {
        _items = new T[length];
        Length = _items.Length;
    }

    // Indexer
    public T this[int index]
    {
        get
        {
            if (index > Length - 1) throw new IndexOutOfRangeException();
            return _items[index];
        }
        set => _items[index] = value;
    }

    /// <summary>
    /// <para>When inserting, all other elements will be shifted to the right.</para>
    /// <para>This will cause all elements out of range to be lost.</para>
    /// </summary>
    public void InsertAt(T item, int index)
    {
        // If inserting at end, change and leave.
        if (index == _items.Length - 1)
        {
            _items[index] = item;
            return;
        }

        // If not, first shift all.
        for (int i = index; i < _items.Length - 1; i++)
        {
            _items[i + 1] = _items[i];
        }

        // And change it now.
        _items[index] = item;

        // If array was already changed before, update Length.
        if (Length != _items.Length)
        {
            Length++;
        }
    }

    public void RemoveAt(int index)
    {
        if (index > _items.Length)
            throw new IndexOutOfRangeException();

        // Shift all first.
        for (int i = index; i < _items.Length - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        // Now update count.
        Length--;
    }
}