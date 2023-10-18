namespace DataStructuresAndAlgorithms.Tests.DataStructures;

public class StaticArrayTests
{
    // Data
    // TODO maybe dry this in the future.
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
    public void Constructor_WithLength_InitializesWithRightCapacity(int length)
    {
        // Arrange
        StaticArray<int> arr = new(length);
        // Assert
        Assert.Equal(length, arr.Capacity);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Capacity_AfterConstructor_IsCorrect(params object[] items)
    {
        // Arrange
        StaticArray<object> arr = new(items);
        // Assert
        Assert.Equal(items.Length, arr.Capacity);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Indexer_InBounds_WorksCorrectly(params object[] items)
    {
        // Arrange
        StaticArray<object> arr = new(items);
        int index = 0;
        // Act
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
    public void InsertAt_ValidIndex_InsertsCorrectly(params object[] items)
    {
        // Arrange
        int index = items.Length - 1;
        object item = items[^1];
        StaticArray<object> actual = new(items);
        StaticArray<object> expected = new(items);
        // Act
        expected[index] = item;
        actual.InsertAt(item, index);
        // Assert
        for (int i = 0; i < expected.Capacity; i++)
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

    [Fact]
    public void InsertAt_ValidItem_KeepsObjectReference()
    {
        // Arrange
        int length = 10;
        int item = 20;
        StaticArray<int> arr = new(length);
        int expected = arr.GetHashCode();
        int actual = 0;
        // Act
        arr.InsertAt(item, 0);
        actual = arr.GetHashCode();
        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InsertAt_EmptyArray_ThrowsOutOfBoundsException()
    {
        // Arrange
        StaticArray<int> arr = new();
        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.InsertAt(1, 0));
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
            StaticArray<object> actual = new(items);
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

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void RemoveAt_InvalidIndex_ShouldThrowOutOfBoundsException(params object[] items)
    {
        // Arrange
        StaticArray<object> arr = new(items);
        // Act && Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.RemoveAt(arr.Capacity));
    }

    [Fact]
    public void RemoveAt_EmptyArray_ThrowsOutOfBoundsException()
    {
        // Arrange
        StaticArray<object> arr = new();
        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.RemoveAt(0));
        
    }
}