namespace DataStructuresAndAlgorithms.Tests.DataStructures;

public class StaticArrayTests
{
    [Fact]
    public void Constructor_WithParameters_InitializesItemsCorrectly()
    {
        // Arrange
        StaticArray<int> arr = new(1, 2, 3);
        // Assert
        Assert.Equal(1, arr[0]);
        Assert.Equal(2, arr[1]);
        Assert.Equal(3, arr[2]);
    }

    [Fact]
    public void Constructor_WithLength_InitializesWithRightLength()
    {
        // Arrange
        StaticArray<int> arr = new(3);
        // Assert
        Assert.Equal(3, arr.Length);
    }

    [Fact]
    public void Length_AfterConstructor_SetsCorrectly()
    {
        // Arrange
        StaticArray<int> arr = new(1, 2, 3);
        // Assert
        Assert.Equal(3, arr.Length);
    }

    [Fact]
    public void Indexer_InBounds_WorksCorrectly()
    {
        // Arrange
        StaticArray<int> arr = new(1, 2, 3);
        // Assert
        Assert.Equal(2, arr[1]);
    }

    [Fact]
    public void Indexer_OutOfBounds_ThrowsOutOfBoundsException()
    {
        // Arrange
        StaticArray<int> arr = new(1, 2, 3);
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr[4]);
    }

    [Fact]
    public void Indexer_OutOfBoundsAfterRemovingElement_ThrowsOutOfBoundsException()
    {
        // Arrange
        StaticArray<int> arr = new(1, 2, 3);
        int index = arr.Length - 1;
        // Act
        arr.RemoveAt(index);
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr[index]);
    }

    [Fact]
    public void InsertAt_ValidIndex_InsertsCorrectly()
    {
        // Arrange
        int index = 1;
        int item = 10;
        StaticArray<int> actual = new(1, 2, 3);
        StaticArray<int> expected = new(1, 10, 2);
        // Act
        actual.InsertAt(item, index);
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
        StaticArray<int> arr = new(1);
        // Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.InsertAt(1, 2));
    }

    [Fact]
    public void RemoveAt_ValidIndex_SetsLengthCorrectly()
    {
        // Arrange
        StaticArray<int> arr = new(1, 2, 3);
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
        StaticArray<int> actual = new(1, 2, 3);
        StaticArray<int> expected = new(1, 3);
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
        StaticArray<int> arr = new(1);
        // Act && Assert
        Assert.Throws<IndexOutOfRangeException>(() => arr.RemoveAt(2));
    }
}