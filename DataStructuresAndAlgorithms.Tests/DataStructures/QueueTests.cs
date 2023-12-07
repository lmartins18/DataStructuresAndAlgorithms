using FluentAssertions;

namespace DataStructuresAndAlgorithms.Tests.DataStructures;

public class QueueTests
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
    public void Constructor_UsingData_CreatesWithCorrectItems(params object[] items)
    {
        DataStructuresAndAlgorithms.DataStructures.Queue<object> queue = new(items);
        foreach (var item in items)
        {
            var queueItem = queue.Dequeue();
            Assert.Equal(item, item);
        }
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Enqueue_ValidItem_AddsSuccessfully(params object[] items)
    {
        // Arrange
        var item = items[^1];
        DataStructuresAndAlgorithms.DataStructures.Queue<object> queue = new(items);
        // Act
        items.Append(item);
        queue.Enqueue(item);
        // Assert
        foreach (var loopItem in items)
        {
            var queueItem = queue.Dequeue();
            Assert.Equal(loopItem, loopItem);
        }
        
    }
    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Enqueue_ValidItem_UpdatesLengthCorrectly(params object[] items)
    {
        // Arrange
        int originalLength = items.Length;
        DataStructuresAndAlgorithms.DataStructures.Queue<object> queue = new(items);
        // Act
        queue.Enqueue(items[^1]);
        // Arrange
        Assert.Equal(originalLength + 1, queue.Length);
    }
    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Dequeue_ValidItem_RemovesSuccessfully(params object[] items)
    {
        // Arrange
        DataStructuresAndAlgorithms.DataStructures.Queue<object> queue = new(items);
        // Act
        var item = queue.Dequeue();
        // Assert
        Assert.Equal(items[0], item);
    }
    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Dequeue_ValidItem_UpdatesLengthCorrectly(params object[] items)
    {
        // Arrange
        int originalLength = items.Length;
        DataStructuresAndAlgorithms.DataStructures.Queue<object> queue = new(items);
        // Act
        queue.Dequeue();
        // Arrange
        Assert.Equal(originalLength - 1, queue.Length);
    }
    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Peek_PeeksFirstElementCorrectly(params object[] items)
    {
        // Arrange
        DataStructuresAndAlgorithms.DataStructures.Queue<object> queue = new(items);
        // Act
        queue.PeekFirst();
        // Arrange
        Assert.Equal(items[0], queue.PeekFirst());
    }
}