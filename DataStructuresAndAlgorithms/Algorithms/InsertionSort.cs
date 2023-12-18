namespace DataStructuresAndAlgorithms.Algorithms;

public class InsertionSort
{
    public static int[] Sort(int[] items)
    {
        // { 12, 11, 13, 5, 6 };
        for (int i = 1; i < items.Length; i++)
        {
            int j = i - 1;
            while (j >= 0 && items[j + 1] < items[j])
            {
                int temp = items[j + 1];
                items[j + 1] = items[j];
                items[j] = temp;
                j--;
            }
        }

        return items;
    }
}