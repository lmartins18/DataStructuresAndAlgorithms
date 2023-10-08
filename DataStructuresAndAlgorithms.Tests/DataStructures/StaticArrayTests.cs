namespace DataStructuresAndAlgorithms.Tests.DataStructures;

public class StaticArrayTests
{
    // Data
    // TODO maybe dry this in the future.
    public static IEnumerable<object[]> GetNumbers()
    {
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
        StaticArray<object> actual = new(items);
        // Assert
        for (int i = 0; i < items.Length; i++)
        {
            Assert.Equal(items[i], actual[i]);
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    public void Constructor_WithLength_InitializesWithRightLength(int length)
    {
        // Arrange
        StaticArray<int> arr = new(length);
        // Assert
        Assert.Equal(length, arr.Length);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Length_AfterConstructor_SetsCorrectly(params object[] items)
    {
        // Arrange
        StaticArray<object> arr = new(items);
        // Assert
        Assert.Equal(items.Length, arr.Length);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Indexer_InBounds_WorksCorrectly(params object[] items)
    {
        // Arrange
        StaticArray<object> arr = new(items);
        int index = items.Length - 1;
        // Assert
        Assert.Equal(items[index], arr[index]);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Indexer_OutOfBounds_ThrowsOutOfBoundsException(params object[] items)
    {
        // Arrange
        StaticArray<object> arr = new(items);
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr[items.Length]);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Indexer_OutOfBoundsAfterRemovingElement_ThrowsOutOfBoundsException(params object[] items)
    {
        // Arrange
        StaticArray<object> arr = new(items);
        int index = arr.Length - 1;
        // Act
        arr.RemoveAt(index);
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr[index]);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void InsertAt_ValidIndex_InsertsCorrectly(params object[] items)
    {
        // Arrange
        int index = 1;
        object item = items[^1];
        StaticArray<object> actual = new(items);
        StaticArray<object> expected = new(items);
        // Act
        expected[index] = item;
        actual.InsertAt(item, index);
        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            object expectedIndex = expected[i];
            object actualIndex = actual[i];

            Assert.True(expectedIndex == actualIndex,
                $"Expected: '{expectedIndex}', Actual: '{actualIndex}' at offset {i}."
            );
        }
    }

    [Fact]
    public void InsertAt_InvalidIndex_ThrowsOutOfBoundsException()
    {
        // Arrange
        int item = 20;
        int length = 10;
        StaticArray<int> arr = new(length);
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.InsertAt(item, length));
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void RemoveAt_ValidIndex_SetsLengthCorrectly(params object[] items)
    {
        // Arrange
        StaticArray<object> arr = new(items);
        int initialLength = arr.Length;
        int expectedLength = initialLength - 1;
        // Act
        arr.RemoveAt(expectedLength);
        // Assert
        Assert.Equal(expectedLength, arr.Length);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void RemoveAt_ValidIndex_RemovesItemSuccessfully(params object[] items)
    {
        // Try at first, 'middle', and last indexes.
        int[] indexes = { 0, 1, items.Length - 1 };
        foreach(var index in indexes)
        {
            // Arrange
            StaticArray<object> actual = new(items);
            StaticArray<object> expected = new(items.Length - 1);
            
            // Add all elements except the one that is going to be removed.
            for (int i = 0, j = 0; i < items.Length; i++)
            {
                if (i != index)
                {
                    expected[j++] = items[i];
                }
            }

            // Act
            actual.RemoveAt(index);
            Assert.Equivalent(expected, actual);
        }
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void RemoveAt_InvalidIndex_ShouldThrowOutOfBoundsException(params object[] items)
    {
        // Arrange
        StaticArray<object> arr = new(items);
        // Act && Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.RemoveAt(items.Length));
    }
}