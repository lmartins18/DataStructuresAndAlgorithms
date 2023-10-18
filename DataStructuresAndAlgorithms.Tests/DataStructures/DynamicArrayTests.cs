namespace DataStructuresAndAlgorithms.Tests.DataStructures;

public class DynamicArrayTests
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
    public void Constructor_WithParameters_InitializesItemsCorrectly(params object[] items)
    {
        // Arrange
        DynamicArray<object> actual = new(items);
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
        DynamicArray<int> arr = new(length);
        // Assert
        Assert.Equal(length, arr.Capacity);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Length_AfterConstructor_SetsCorrectly(params object[] items)
    {
        // Arrange
        DynamicArray<object> arr = new(items);
        // Assert
        Assert.Equal(items.Length, arr.Capacity);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Indexer_InBounds_WorksCorrectly(params object[] items)
    {
        // Arrange
        DynamicArray<object> arr = new(items);
        int index = (items.Length > 0) ? items.Length - 1 : 0;
        // Assert
        Assert.Equal(items[index], arr[index]);
        
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Indexer_OutOfBounds_ThrowsOutOfBoundsException(params object[] items)
    {
        // Arrange
        DynamicArray<object> arr = new(items);
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr[items.Length]);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Add_NewItem_AddsAtEndCorrectly(params object[] items)
    {
        // Arrange
        DynamicArray<object> arr = new(items);
        object item = arr.Count > 0 ? items[0] : default!;
        // Act
        arr.Add(item);
        // Assert
        Assert.Equal(item, arr[^1]);
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void Add_NewItem_UpdatesCountCorrectly(params object[] items)
    {
        // Arrange
        DynamicArray<object> arr = new(items);
        object item = items[^1];
        int initialLength = arr.Count;
        int expectedLength = initialLength + 1;
        // Act
        arr.Add(item);
        // Assert
        Assert.Equal(expectedLength, arr.Count);
    }
    
    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void InsertAt_ValidIndex_InsertsCorrectly(params object[] items)
    {
        // Insert at start, middle and end.
        int[] indexes = { 0, 1, items.Length - 1 };
        foreach (var index in indexes)
        {
            // Arrange
            object item = 10; // Item to insert
            DynamicArray<object> actual = new(items);
            List<object> expected = new(items);
            List<object> test = new(10);

            // Act
            expected.Insert(index, item);
            actual.InsertAt(item, index);

            // Assert
            for (int i = 0; i < expected.Count(); i++)
            {
                object expectedIndex = expected[i];
                object actualIndex = actual[i];

                Assert.True(expectedIndex == actualIndex,
                    $"Expected: '{expectedIndex}', Actual: '{actualIndex}' at offset {i}."
                );
            }
        }
    }


    [Fact]
    public void InsertAt_InvalidIndex_ThrowsOutOfBoundsException()
    {
        // Arrange
        int length = 1;
        DynamicArray<int> arr = new(length);
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.InsertAt(length, length + 1));
    }

    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void RemoveAt_ValidIndex_SetsLengthCorrectly(params object[] items)
    {
        // Arrange
        DynamicArray<object> arr = new(items);
        int initialLength = arr.Count;
        int expectedLength = initialLength - 1;
        // Act
        arr.RemoveAt(expectedLength);
        // Assert
        Assert.Equal(expectedLength, arr.Count);
    }


    [Theory]
    [MemberData(nameof(GetNumbers))]
    public void RemoveAt_ValidIndex_RemovesItemSuccessfully(params object[] items)
    {
        // Try at first, 'middle', and last indexes.
        int[] indexes = { 0, 1, items.Length - 1 };
        foreach (var index in indexes)
        {
            // Arrange
            DynamicArray<object> actual = new(items);
            List<object> expected = new(items);
            // Skip empty arrays.
            if (index >= expected.Count) return; 
            // Act
            actual.RemoveAt(index);
            expected.RemoveAt(index);
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
        DynamicArray<object> arr = new(items);
        // Act && Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.RemoveAt(items.Length));
    }
}