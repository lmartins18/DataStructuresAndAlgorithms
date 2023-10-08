namespace DataStructuresAndAlgorithms.Tests.DataStructures;

using DataStructuresAndAlgorithms.DataStructures;

public class StackTests
{
    [Fact]
    public void Constructor_WithParameters_InitializesItemsCorrectly()
    {
        // Arrange
        Stack<int> arr = new(1, 2, 3);
        // Act & Assert
        // Pop and check that item returned is correct.
        Assert.Equal(3, arr.Pop());
        Assert.Equal(2, arr.Pop());
        Assert.Equal(1, arr.Pop());
    }

    [Fact]
    public void Constructor_WithElements_InitializesWithRightLength()
    {
        // Arrange
        Stack<int> arr = new(1, 2, 3);
        // Assert
        Assert.Equal(3, arr.Length);
    }

    [Fact]
    public void Pop_ValidStack_ReturnsLastElement()
    {
        // Arrange
        Stack<int> actual = new(1, 2, 3);
        Stack<int> expected = new(1, 2);
        // Act 
        actual.Pop();
        // Assert
        Assert.Equivalent(expected, actual);
    }

    [Fact]
    public void Pop_ValidStack_UpdatesLengthCorrectly()
    {
        // Arrange
        Stack<int> actual = new(1, 2, 3);
        int expectedLength = actual.Length - 1;
        // Act 
        actual.Pop();
        // Assert
        Assert.Equal(expectedLength, actual.Length);
    }

    [Fact]
    public void Pop_EmptyStack_ThrowsInvalidOperationException()
    {
        // Arrange
        Stack<int> actual = new();
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => actual.Pop());
    }

    [Fact]
    public void Push_AddItem_AddsElementToEndOfStack()
    {
        // Arrange
        const int item = 2;
        Stack<int> actual = new(1);
        Stack<int> expected = new(1, item);
        // Act 
        actual.Push(item);
        // Assert
        Assert.Equivalent(expected, actual);
    }
    [Fact]
    public void Push_AddItem_UpdatesLengthCorrectly()
    {
        // Arrange
        int item = 2;
        Stack<int> actual = new(1);
        int expectedLength = actual.Length + 1;
        // Act 
        actual.Push(item);
        // Assert
        Assert.Equal(expectedLength, actual.Length);
    }

    [Fact]
    public void Peek_GetsLastElement()
    {
        // Arrange
        Stack<int> actual = new(1, 2);
        int expectedItem = 2;
        int actualItem = actual.Peek();
        // Assert
        Assert.Equal(expectedItem, actualItem);
    }
    [Fact]
    public void Peek_DoesNotRemoveLastElement()
    {
        // Arrange
        Stack<int> actual = new(1, 2);
        Stack<int> expected = new(1, 2);
        // Assert
        Assert.Equivalent(expected, actual);
    }
    [Fact]
    public void Peek_DoesNotChangeLength()
    {
        // Arrange
        Stack<int> arr = new(1, 2);
        int expected = 2;
        int actual = arr.Length;
        // Assert
        Assert.Equivalent(expected, actual);
    }
}