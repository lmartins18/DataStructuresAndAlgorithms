using System.Globalization;

namespace DataStructuresAndAlgorithms.DataStructures;

public class LinkedList<T>
{
    public LinkedListNode<T> Head { get; private set; }
    public LinkedListNode<T> Tail { get; private set; }
    public int Length { get; private set; }

    public sealed class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T>? Next { get; set; } = null;

        public LinkedListNode(T value)
        {
            Value = value;
            Next = null;
        }
    }

    public LinkedList()
    {
        Head = null!;
        Tail = null!;
    }

    public LinkedList(params T[] items)
    {
        Head ??= new LinkedListNode<T>(items[0]);
        Tail = Head;
        for (int i = 1; i < items.Length; i++)
        {
            var item = new LinkedListNode<T>(items[i]);
            Tail.Next = item;
            Tail = item;
        }

        Length = items.Length;
    }

    // Indexer
    public T this[int index]
    {
        get
        {
            if (index >= Length) throw new IndexOutOfRangeException();
            var value = this.Head;
            for (int i = 0; i < index; i++)
            {
                value = value.Next;
            }

            return value.Value;
        }
        set
        {
            if (index >= Length) throw new IndexOutOfRangeException();
            var val = this.Head;
            for (int i = 0; i < index; i++)
            {
                val = val.Next;
            }

            val.Value = value;
        }
    }

    // InsertAt
    public void InsertAt(T item, int index)
    {
        if (index >= Length) throw new IndexOutOfRangeException();
        LinkedListNode<T> old = null;
        var newNode = new LinkedListNode<T>(item);
        // If inserting at start, change and leave.
        if (index == 0)
        {
            old = Head;
            Head = newNode;
            Head.Next = old;
        }
        else
        {
            old = Head;
            for (int i = 0; i < index - 1; i++)
            {
                old = old.Next;
            }

            newNode = new LinkedListNode<T>(item);
            newNode.Next = old;
            old.Next = newNode;
        }

        // If added at end, update tail.
        if (index == Length - 1)
        {
            Tail = newNode;
        }

        Length++;
        // Save this for dobule linked list.
        // If inserting at end, change and leave.
        // if (index == Length - 1)
        // {
        //     old = Tail;
        //     Tail = new LinkedListNode<T>(item);
        //     Tail.Next = old;
        //     return;
        // }
        // If not, first get existing item.
    }

    // Add
    public void AddLast(T item)
    {
        LinkedListNode<T> newItem = new(item);
        newItem.Next = Tail;
        Tail = newItem;
    }

    public void AddFist(T item) => InsertAt(item, 0);

    // Remove
    public void RemoveAt(int index)
    {
        if (index >= Length) throw new IndexOutOfRangeException();
        LinkedListNode<T> node = null!;
        // Check if removing first element.
        if (index == 0)
        {
            // Check if removing last element in the list.
            if (Head.Next is not null)
            {
                node = Head.Next;
                Head = node;
            }
            else
            {
                // Set list to empty.
                Head = null!;
                Tail = null!;
            }
        }
        else
        {
            node = Head;
            // Loop til element that comes before the element that we want to remove.
            for (int i = 0; i < index - 1; i++)
            {
                node = node.Next;
            }

            // If removing last element, set its next to null.
            node.Next = (node.Next == Tail) ? null : node.Next.Next;
        }

        // If now, the element is the last, update tail.
        if (node?.Next == null)
        {
            Tail = node;
        }

        Length--;
    }

    public void RemoveLast()
    {
        RemoveAt(Length - 1);

    }

    public void RemoveFirst()
    {
        Head = Head.Next;
    }
}