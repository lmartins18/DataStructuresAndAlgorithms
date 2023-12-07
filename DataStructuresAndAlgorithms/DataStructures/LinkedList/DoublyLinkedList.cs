namespace DataStructuresAndAlgorithms.Tests.DataStructures;

public class DoublyLinkedList<T>
{
    public DoublyLinkedListNode<T> Head { get; private set; }
    public DoublyLinkedListNode<T> Tail { get; private set; }
    public int Length { get; private set; }

    public sealed class DoublyLinkedListNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedListNode<T>? Prev { get; set; } = null;
        public DoublyLinkedListNode<T>? Next { get; set; } = null;

        public DoublyLinkedListNode(T value)
        {
            Value = value;
            Prev = null;
            Next = null;
        }

        public DoublyLinkedListNode()
        {
            Value = default!;
            Prev = null;
            Next = null;
        }
    }

    public DoublyLinkedList()
    {
        Head = null!;
        Tail = null!;
    }

    public DoublyLinkedList(params T[] items)
    {
        Head ??= new DoublyLinkedListNode<T>(items[0]);
        Tail = Head;
        Tail.Prev = Head;
        Head.Prev = null;
        for (int i = 1; i < items.Length; i++)
        {
            DoublyLinkedListNode<T> item = new()
            {
                Value = items[i],
                Prev = Tail
            };
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
            // TODO make this more efficient, if index > half, go backwards.
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
        DoublyLinkedListNode<T> oldNode = null;
        var newNode = new DoublyLinkedListNode<T>(item);
        // If inserting at start, change and leave.
        if (index == 0)
        {
            oldNode = Head;
            Head = newNode;
            Head.Next = oldNode;
            oldNode.Prev = newNode;
        }
        else
        {
            oldNode = Head;
            for (int i = 0; i < index - 1; i++)
            {
                oldNode = oldNode.Next;
            }

            newNode = new DoublyLinkedListNode<T>()
            {
                Value = item,
                Next = oldNode,
                Prev = oldNode.Prev
            };
            oldNode.Prev = newNode;
        }

        // If added at end, update tail.
        if (index == Length - 1)
        {
            AddLast(item);
        }

        Length++;
    }

    // Add
    public void AddLast(T item)
    {
        DoublyLinkedListNode<T> newItem = new()
        {
            Value = item,
            Next = null,
            Prev = Tail
        };
        Tail = newItem;
    }

    public void AddFist(T item) => InsertAt(item, 0);

    // Remove
    public void RemoveAt(int index)
    {
        if (index >= Length) throw new IndexOutOfRangeException();
        DoublyLinkedListNode<T> node = null!;
        // Check if removing first element.
        if (index == 0)
        {
            RemoveFirst();
        }
        else if (index == Length - 1) // End
        {
            RemoveLast();
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
            Length--;
        }

        // If now, the element is the last, update tail.
        if (node?.Next == null)
        {
            Tail = node;
        }

    }

    public void RemoveLast()
    {
        if (Length == 0) 
            throw new IndexOutOfRangeException("List is empty.");

        Tail = Tail.Prev;
        Length--;
    }

    public void RemoveFirst()
    {
        if (Length == 0) throw new IndexOutOfRangeException("List is empty.");

        Head = Head.Next;
        if (Head is null)
        {
            Tail = null;
        }

        Length--;
    }
}