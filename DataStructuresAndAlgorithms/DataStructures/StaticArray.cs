namespace DataStructuresAndAlgorithms.DataStructures;

public class StaticArray<T>
{
    private T[] _items;
    public int Length => _items.Length;

    public StaticArray(params T[] items) => _items = items;
    public StaticArray(int length) => _items = new T[length];

    // Indexer
    public T this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }

    // Insert
    public void Add(T item)
    {
        // Create a new array with current length + 1
        T[] newArr = new T[_items.Length + 1];
        // Add current items + new item;
        newArr[^1] = item;
        _items = newArr;
    }

    public void InsertAt(T item, int index)
    {
        // Create a new array with current length + 1
        T[] newArr = new T[_items.Length + 1];
        // Loop array. Add until desired index is reached. 
        for (int i = 0; i < index; i++)
        {
            newArr[i] = _items[i];
        }

        newArr[index] = item;

        for (int j = index + 1; j < newArr.Length; j++)
        {
            newArr[j] = _items[j - 1];
        }

        _items = newArr;
    }

    // Remove
    public void RemoveAt(int index)
    {
        // New array to store existing values
        T[] newArr = new T[_items.Length - 1];
        // Loop till index.
        for (int i = 0; i < index; i++)
        {
            newArr[i] = _items[i];
        }
        for (int j = index; j < newArr.Length; j++)
        {
            newArr[j] = _items[j + 1];
        }

        _items = newArr;
    }
}