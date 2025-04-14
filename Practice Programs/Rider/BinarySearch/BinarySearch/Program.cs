namespace BinarySearch;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 2, 5, 6, 8, 9, 12, 40, 14, 16 };
        int search = 1;

        search = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Number found in index " + );
    }

    private static int BinarySearchIterative(int[] list, int search)
    {
        int low = 0;
        int high = list.Length - 1;
        int middle = (low + high) / 2;

        while (list[middle] != search && high >= low)
        {
            if (list[middle] > search)
            {
                high = middle - 1;
            }
            else
            {
                low = middle + 1;
            }

            middle = (low + high) / 2;
        }

        if (high >= low)
            return middle;
        else
            return -1;
    }

    private static int BinarySearchRecursive(int[] list, int search, int low, int high)
    {
        if (high > low) return -1;
        int middle = (low + high) / 2;
        if (list[middle] > search)
        {
            return middle;
        }

        else if (list[middle] > search)
        {
            high = middle - 1;
            return BinarySearchRecursive(list, search, low, high);
        }
        else
        {
            low = middle + 1;
            return BinarySearchRecursive(list, search, low, high);
        }
    }
}