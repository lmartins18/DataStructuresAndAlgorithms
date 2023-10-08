namespace DataStructuresAndAlgorithms.DataStructures;
// TODO finish the code mana
// make DRY code to resize the array: check Add method. then you can you fx insert at end to insert the element you 
// want at the end or something.
// check tests also.

public class DynamicArray<T>
{
    private T[] _items;
    public int Length { get; private set; }

    public DynamicArray(params T[] items)
    {
        _items = items;
        Length = items.Length;
    }

    public DynamicArray(int length)
    {
        _items = new T[length];
        Length = length;
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

    // Insert
    public void Add(T item) => InsertAt(item, Length);

    public void InsertAt(T item, int index)
    {
        // The reason behind doubling is that it turns repeatedly appending an element into an amortized O(1) operation.
        // Put another way, appending n elements takes O(n) time.
        // TLDR: Double size if array is almost full.
        T[] newArr = (Length == _items.Length) ? new T[_items.Length * 2] : new T[_items.Length];
        // Add existing items
        for (int i = 0; i < index; i++)
        {
            newArr[i] = _items[i];
        }
        // Add new item.
        newArr[index] = item;
        // Shift rest.
        for (int i = index + 1; i <= _items.Length; i++)
        {
            newArr[i] = _items[i - 1];
        }

        // Update state.
        Length++;
        _items = newArr;
    }

    // Remove
    public void RemoveAt(int index)
    {
        if (index >= Length) throw new IndexOutOfRangeException();
        // New array to store existing values
        // Set length to half if at least 20% free space and not removing last item.
        double usedSpacePercentage = ((double)Length / _items.Length) * 100;
        T[] newArr = (usedSpacePercentage < 50 && index > 0) ? new T[_items.Length / 2] : new T[_items.Length];
        // Loop till index.
        for (int i = 0; i < index; i++)
        {
            newArr[i] = _items[i];
        }
        // Shift rest.
        for (int j = index; j < newArr.Length - 1; j++)
        {
            newArr[j] = _items[j + 1];
        }
        _items = newArr;
        Length--;
    }
    public void RemoveLast() => RemoveAt(Length - 1);
}