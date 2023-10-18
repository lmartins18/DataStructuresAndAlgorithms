namespace DataStructuresAndAlgorithms.DataStructures;
// TODO finish the code mana
// make DRY code to resize the array: check Add method. then you can you fx insert at end to insert the element you 
// want at the end or something.
// check tests also.

public class DynamicArray<T>
{
    private StaticArray<T> _items;
    // To hold 'count' of items. Needed so arrays can't be index when instantiated with capacity instead of items.
    // Otherwise, arrays are instantiated with null values and can be indexed incorrectly.
    public int Capacity { get; private set; }
    public int Count { get; private set; }

    public DynamicArray(params T[] items)
    {
        _items = new(items);
        Capacity = items.Length;
        Count = Capacity;
    }

    public DynamicArray(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException("Invalid length");

        _items = capacity == 0 ? new(0) : new(capacity) ;
        Capacity = capacity;
    }
    // Indexer
    public T this[int index]
    {
        get
        {
            if (index > Count) 
                throw new IndexOutOfRangeException();
            
            return _items[index];
        }
        set
        {
            if (index > Count) 
                throw new IndexOutOfRangeException();
            
            _items[index] = value;
        }
    }

    // Insert
    public void Add(T item) => InsertAt(item, Count);

    public void InsertAt(T item, int index)
    {
        bool isAtFullCapacity = Count + 1 >= Capacity;
        // If array has space just add it using static array insert method.
        // TODO test this.
        if (!isAtFullCapacity)
        {
            _items.InsertAt(item, index);
            Count++;
            return;
        }
        //Handle empty array.
        // The reason behind doubling is that it turns repeatedly appending an element into an amortized O(1) operation.
        // Put another way, appending n elements takes O(n) time.
        // TLDR: Double size if array is almost full.
        StaticArray<T> newArr = new(Capacity * 2);
        // Add existing items
        for (int i = 0; i < index; i++)
        {
            newArr[i] = _items[i];
        }
        // Add new item.
        newArr[index] = item;
        // Shift rest.
        for (int i = index + 1; i <= Capacity; i++)
        {
            newArr[i] = _items[i - 1];
        } 
        // Update state.
        Count++;
        Capacity = newArr.Capacity;
        _items = newArr;
    }

    // Remove
    public void RemoveAt(int index)
    {
        if (index >= Capacity) throw new IndexOutOfRangeException();
        // New array to store existing values
        // Set length to half if at least 20% free space and not removing last item.
        double usedSpacePercentage = ((double)Capacity / _items.Capacity) * 100;
        StaticArray<T> newArr = (usedSpacePercentage < 50 && index > 0) ? new(_items.Capacity / 2) : new(_items.Capacity);
        // Loop till index.
        for (int i = 0; i < index; i++)
        {
            newArr[i] = _items[i];
        }
        // Shift rest.
        for (int j = index; j < newArr.Capacity - 1; j++)
        {
            newArr[j] = _items[j + 1];
        }
        _items = newArr;
        Count--;
    }
    public void RemoveLast() => RemoveAt(Capacity - 1);
}