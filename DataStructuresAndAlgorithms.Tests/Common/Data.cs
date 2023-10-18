namespace DataStructuresAndAlgorithms.Tests.Common;

public class Data
{
    public static IEnumerable<object[]> GetNumbers()
    {
        yield return new object[] { 1, 2, 3 };
        yield return new object[] { 3, 2, 1 };
        yield return new object[] { 1, 3, 2 };
        yield return new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    }
}