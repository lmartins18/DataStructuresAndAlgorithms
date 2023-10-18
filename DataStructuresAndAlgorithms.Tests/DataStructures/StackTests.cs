namespace DataStructuresAndAlgorithms.Tests.DataStructures;

using DataStructuresAndAlgorithms.DataStructures;

public class StackTests
{
    // Data
    // TODO dry this.
    public static IEnumerable<object[]> GetNumbers()
    {
        yield return new object[] { 1 };
        yield return new object[] { 1, 2 };
        yield return new object[] { 1, 2, 3 };
        yield return new object[] { 3, 2, 1 };
        yield return new object[] { 1, 3, 2 };
        yield return new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Constructor_WithParameters_InitializesItemsCorrectly(params object[] items)
    {
        // Arrange
        Stack<object> arr = new(items);
        // Act & Assert
        // Pop and check that item returned is correct.
        // Assert
        for (int i = items.Length - 1; i > 0; i--)
        {
            var item = arr.Pop();
            Assert.Equal(items[i], item);
        }
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Constructor_WithElements_InitializesWithRightLength(params object[] items)
    {
        // Arrange
        Stack<object> arr = new(items);
        // Assert
        Assert.Equal(items.Length, arr.Length);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Pop_ValidStack_ReturnsLastElement(params object[] items)
    {
        // Arrange & Act
        Stack<object> actual = new(items);
        object expectedItem = items[^1];
        object actualItem = actual.Pop();
        // Act 
        // Assert
        Assert.Equal(expectedItem, actualItem);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Pop_ValidStack_RemovesLastElement(params object[] items)
    {
        // Arrange & Act
        Stack<object> actual = new(items);
        Stack<object> expected = new(items[0..^1]); // All but last.
        // Act 
        actual.Pop();
        // Assert
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Pop_ValidStack_UpdatesLengthCorrectly(params object[] items)
    {
        // Arrange
        Stack<object> actual = new(items);
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

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Push_AddItem_AddsElementToEndOfStack(params object[] items)
    {
        // Arrange
        object item = items[^1];
        Stack<object> actual = new(items);
        List<object> expected = new(items);
        // Act 
        expected.Add(item);
        actual.Push(item);
        // Assert
        Assert.Equal(expected[^1], actual.Peek());
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Push_AddItem_UpdatesLengthCorrectly(params object[] items)
    {
        // Arrange
        object item = items[^1];
        Stack<object> actual = new(items);
        int expectedLength = actual.Length + 1;
        // Act 
        actual.Push(item);
        // Assert
        Assert.Equal(expectedLength, actual.Length);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Peek_GetsLastElement(params object[] items)
    {
        // Arrange
        Stack<object> actual = new(items);
        object expectedItem = items[^1];
        object actualItem = actual.Peek();
        // Assert
        Assert.Equal(expectedItem, actualItem);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Peek_DoesNotRemoveLastElement(params object[] items)
    {
        // Arrange
        Stack<object> actual = new(items);
        Stack<object> expected = new(items);
        // Act
        actual.Peek();
        // Assert
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Peek_DoesNotChangeLength(params object[] items)
    {
        // Arrange
        Stack<object> arr = new(items);
        int expectedLength = arr.Length;
        // Act
        arr.Peek();
        // Assert
        Assert.Equivalent(expectedLength, arr.Length);
    }
}