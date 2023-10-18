namespace DataStructuresAndAlgorithms.Tests.DataStructures;

using DataStructuresAndAlgorithms.DataStructures;

public class LinkedListTests
{
    // Data
    public static IEnumerable<object[]> GetNumbers()
    {
        yield return new object[] { 1 };
        yield return new object[] { 1, 2 };
        yield return new object[] { 1, 2, 3 };
        yield return new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Constructor_ValidData_ConstructsCorrectly(params object[] items)
    {
        // Arrange
        LinkedList<object> actual = new LinkedList<object>(items);
        // Assert
        var currentNode = actual.Head; // Start from the first node

        for (var i = 0; i < items.Length; i++)
        {
            Assert.NotNull(currentNode); // Ensure the node exists

            var item = items[i];
            Assert.Equal(item, currentNode.Value);

            currentNode = currentNode.Next; // Move to the next node
        }

        Assert.Null(currentNode); // Ensure that we have reached the end of the list
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Constructor_ValidData_SetsLengthCorrectly(params object[] items)
    {
        // Arrange
        LinkedList<object> arr = new LinkedList<object>(items);
        // Act & Assert
        Assert.Equal(arr.Length, items.Length);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Indexer_Get_GetsCorrectly(params object[] items)
    {
        int[] indexes = { 0, 1, items.Length - 1 };
        foreach (var index in indexes)
        {
            // Skip empty arrays.
            if (index >= items.Count()) return;
            // For some reason range index like ^1 cant be used..
            // Arrange
            LinkedList<object> arr = new(items);
            object expected = items[index];
            object actual = arr[index];
            // Assert
            Assert.Equal(expected, actual);
        }
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Indexer_Set_SetsCorrectly(params object[] items)
    {
        // For some reason range index like ^1 cant be used..
        // Arrange
        LinkedList<object> arr = new(items);
        object expected = items[0];
        object actual = default;
        // Act
        arr[items.Length - 1] = items[0];
        actual = arr[items.Length - 1];
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Indexer_InvalidIndex_ThrowsOutOfBoundsException()
    {
        // Arrange
        LinkedList<object> arr = new();
        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr[10]);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void InsertAt_ValidIndex_InsertsCorrectly(params object[] items)
    {
        int[] indexes = { 0, 1, items.Length - 1 };
        foreach (var index in indexes)
        {
            // Skip empty arrays.
            if (index >= items.Count()) return;
            // Arrange
            LinkedList<object> arr = new(items);
            object expected = items[0];
            object actual = default;
            // Act
            arr.InsertAt(expected, index);
            actual = arr[index];
            // Assert
            Assert.Equal(expected, actual);
        }
    }

    [Fact]
    public void InsertAt_InvalidIndex_ThrowsOutOfBoundsException()
    {
        // Arrange
        LinkedList<object> arr = new();
        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.InsertAt(1, 10));
    }

    [Fact]
    public void InsertAt_FirstElement_UpdatesHeadCorrectly()
    {
        // Arrange
        int item = 0;
        LinkedList<int> arr = new(1);
        // Act
        arr.InsertAt(item, 0);
        // Assert
        Assert.Equal(arr.Head.Value, item);
    }

    [Fact]
    public void InsertAt_LastElement_UpdatesTailCorrectly()
    {
        // Arrange
        int item = 2;
        LinkedList<int> arr = new(0, 1);
        // Act
        arr.InsertAt(item, 1);
        // Assert
        Assert.Equal(arr.Tail.Value, item);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void RemoveAt_ValidIndex_RemovesItemSuccessfully(params object[] items)
    {
        // This is only for substantial arrays, skip empty/
        // Try at first, 'middle', and last indexes.
        int[] indexes = { 0, 1, items.Length - 1 };
        foreach (var index in indexes)
        {
            // Arrange
            LinkedList<object> actual = new(items);
            List<object> expected = new(items);
            // Skip empty arrays.
            if (index >= expected.Count) return;
            // Act
            expected.RemoveAt(index);
            actual.RemoveAt(index);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i], actual[i]);
            }
        }
    }

    [Fact]
    public void AddLast_UpdatesTailCorrectly()
    {
        // Arrange
        int item = 2;
        LinkedList<int> arr = new(1);
        // Act
        arr.AddLast(item);
        // Assert
        Assert.Equal(arr.Tail.Value, item);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void AddLast_AddsItemCorrectly(params object[] items)
    {
        // Arrange
        object item = items[0];
        LinkedList<object> actual = new(items);
        List<object> expected = new(items);
        // Act
        actual.AddLast(item);
        expected.Add(item);
        // Assert
        for (var i = 0; i < items.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void AddFirst_UpdatesHeadCorrectly(params object[] items)
    {
        // Arrange
        var item = items[0];
        LinkedList<object> arr = new(items);
        // Act
        arr.AddFist(item);
        // Assert
        Assert.Equal(arr.Head.Value, item);
    }

    [Fact]
    public void RemoveFirst_UpdatesHeadCorrectly()
    {
        // Arrange
        int[] items = { 1, 2 };
        LinkedList<int> arr = new(items);
        // Act
        arr.RemoveFirst();
        // Assert
        Assert.Equal(arr.Head.Value, items[1]);
    }
    [Fact]
    public void RemoveFirst_UpdatesFirstItemCorrectly()
    {
        // Arrange
        int[] items = { 1, 2 };
        LinkedList<int> arr = new(items);
        // Act
        arr.RemoveFirst();
        // Assert
        Assert.Equal(arr[0], items[1]);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void RemoveLast_UpdatesTailCorrectly(params object[] items)
    {
        // Arrange
        LinkedList<object> arr = new(items);
        // Act
        arr.RemoveLast();
        // Assert
        if(arr.Length == 0) return;
        Assert.Equal(arr.Tail.Value, items[^2]);
    }
    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void RemoveLast_UpdatesLastItemCorrectyl(params object[] items)
    {
        // Arrange
        LinkedList<object> arr = new(items);
        // Act
        arr.RemoveLast();
        // Assert
        if(arr.Length == 0) return;
        Assert.Equal(items[^2], arr.Tail.Value);
    }
}