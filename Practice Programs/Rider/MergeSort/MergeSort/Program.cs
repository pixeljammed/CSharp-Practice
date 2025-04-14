namespace MergeSort;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }

    static void MergeSort(int[] array)
    {
        if (array.Length < 2)
        {
            return;
        }
        else
        {
            int midpoint = array.Length / 2;
            int[] left_half = new int[midpoint];
            Array.Copy(array, left_half, midpoint);
            int[] right_half = new int[array.Length - midpoint];
            Array.Copy(array, right_half, array.Length - midpoint);

            MergeSort(left_half);
            MergeSort(right_half);

            Merge(array, left_half, right_half);
        }
    }
}