namespace DataStructuresAndAlgorithms.Tests.DataStructures;

public class DynamicArrayTests
{
    [Fact]
    public void Constructor_WithParameters_InitializesItemsCorrectly()
    {
        // Arrange
        DynamicArray<int> arr = new(1, 2, 3);
        // Assert
        Assert.Equal(1, arr[0]);
        Assert.Equal(2, arr[1]);
        Assert.Equal(3, arr[2]);
    }

    [Fact]
    public void Constructor_WithLength_InitializesWithRightLength()
    {
        // Arrange
        DynamicArray<int> arr = new(3);
        // Assert
        Assert.Equal(3, arr.Length);
    }

    [Fact]
    public void Length_AfterConstructor_SetsCorrectly()
    {
        // Arrange
        DynamicArray<int> arr = new(1, 2, 3);
        // Assert
        Assert.Equal(3, arr.Length);
    }

    [Fact]
    public void Indexer_InBounds_WorksCorrectly()
    {
        // Arrange
        DynamicArray<int> arr = new(1, 2, 3);
        // Assert
        Assert.Equal(2, arr[1]);
    }

    [Fact]
    public void Indexer_OutOfBounds_ThrowsOutOfBoundsException()
    {
        // Arrange
        DynamicArray<int> arr = new(1, 2, 3);
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr[4]);
    }

    [Fact]
    public void Add_NewItem_AddsAtEndCorrectly()
    {
        // Arrange
        DynamicArray<int> arr = new(1, 2, 3);
        int item = 4;
        // Act
        arr.Add(item);
        // Assert
        Assert.Equal(item, arr[3]);
    }

    [Fact]
    public void Add_NewItem_UpdatesLengthCorrectly()
    {
        // Arrange
        DynamicArray<int> arr = new(1, 2, 3);
        // Act
        arr.Add(4);
        // Assert
        Assert.True(arr.Length == 4, $"Expected: 4, actual: {arr.Length}");
    }

    [Fact]
    public void InsertAt_ValidIndex_InsertsCorrectly()
    {
        // Arrange
        DynamicArray<int> actual = new(1, 2, 3);
        DynamicArray<int> expected = new(2, 1, 2, 3);
        // Act
        actual.InsertAt(2, 0);
        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            int expectedIndex = expected[i];
            int actualIndex = actual[i];

            Assert.True(expectedIndex == actualIndex,
                $"Expected: '{expectedIndex}', Actual: '{actualIndex}' at offset {i}."
            );
        }
    }

    [Fact]
    public void InsertAt_InvalidIndex_ThrowsOutOfBoundsException()
    {
        // Arrange
        DynamicArray<int> arr = new(1);
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.InsertAt(1, 2));
    }

    [Fact]
    public void RemoveAt_ValidIndex_SetsLengthCorrectly()
    {
        // Arrange
        DynamicArray<int> arr = new(1, 2, 3);
        int initialLength = arr.Length;
        // Act
        arr.RemoveAt(1);
        // Assert
        Assert.True(arr.Length == initialLength - 1);
    }

    [Fact]
    public void RemoveAt_ValidIndex_RemovesItemSuccessfully()
    {
        // Arrange
        DynamicArray<int> actual = new(1, 2, 3);
        DynamicArray<int> expected = new(1, 3);
        // Act
        actual.RemoveAt(1);
        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            int expectedIndex = expected[i];
            int actualIndex = actual[i];

            Assert.True(expectedIndex == actualIndex,
                $"Expected: '{expectedIndex}', Actual: '{actualIndex}' at offset {i}."
            );
        }
    }

    [Fact]
    public void RemoveAt_InvalidIndex_ShouldThrowOutOfBoundsException()
    {
        // Arrange
        DynamicArray<int> arr = new(1);
        // Act && Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.RemoveAt(2));
    }

    [Fact]
    public void RemoveLast_RemovesLastElementSuccessfully()
    {
        // Arrange
        DynamicArray<int> actual = new(1, 2, 3);
        DynamicArray<int> expected = new(1, 2);;
        // Act
        actual.RemoveLast();
        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            int expectedIndex = expected[i];
            int actualIndex = actual[i];

            Assert.True(expectedIndex == actualIndex,
                $"Expected: '{expectedIndex}', Actual: '{actualIndex}' at offset {i}."
            );
        }
    }
}