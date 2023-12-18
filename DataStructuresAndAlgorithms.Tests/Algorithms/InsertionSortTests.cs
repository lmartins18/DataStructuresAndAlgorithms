using DataStructuresAndAlgorithms.Algorithms;

namespace DataStructuresAndAlgorithms.Tests.Algorithms;

public class InsertionSortTests
{
    [Fact]
    public void InsertionSort_SortsCorrectly()
    {
        // Arrange
        int[] expected = new[] { 12, 11, 13, 5, 6 };
        int[] actual = new[] { 5, 6, 11, 12, 13 };
        // Act
        expected = InsertionSort.Sort(expected);
        // Assert
        Assert.Equal(expected, actual);
    }
}