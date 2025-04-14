using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {

        static void BubbleSort(int[] array)
        {
            int comparisons = 0;
            int assignments = 0;
            int n = array.Length;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    comparisons++; // Increment comparison counter
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        assignments += 2; // Each swap has 2 assignments
                    }
                }
            }
            Console.WriteLine($"Bubble Sort - Comparisons: {comparisons}, Assignments: {assignments}, Total: {comparisons + assignments}");
        }

        static void SelectionSort(int[] array)
        {
            int comparisons = 0;
            int assignments = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    comparisons++; // Increment comparison counter
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(ref array[i], ref array[min]);
                    assignments += 2; // Each swap has 2 assignments
                }
            }
            Console.WriteLine($"Selection Sort - Comparisons: {comparisons}, Assignments: {assignments}, Total: {comparisons + assignments}");
        }

        static void InsertionSort(int[] array)
        {
            int comparisons = 0;
            int assignments = 0;
            int n = array.Length;
            for (int i = 1; i <= n - 1; i++)
            {
                int temp = array[i];
                assignments++; // Assignment of temp
                int j = i - 1;
                while (j >= 0 && array[j] > temp)
                {
                    comparisons++; // Increment comparison counter
                    array[j + 1] = array[j];
                    assignments++; // Assignment in the array
                    j--;
                }
                if (j >= 0) comparisons++; // Final comparison where condition fails
                array[j + 1] = temp;
                assignments++; // Final assignment
            }
            Console.WriteLine($"Insertion Sort - Comparisons: {comparisons}, Assignments: {assignments}, Total: {comparisons + assignments}");
        }

        static void Swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        private static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {

        static void BubbleSort(int[] array)
        {
            int comparisons = 0;
            int assignments = 0;
            int n = array.Length;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    comparisons++; // Increment comparison counter
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        assignments += 2; // Each swap has 2 assignments
                    }
                }
            }
            Console.WriteLine($"Bubble Sort - Comparisons: {comparisons}, Assignments: {assignments}, Total: {comparisons + assignments}");
        }

        static void SelectionSort(int[] array)
        {
            int comparisons = 0;
            int assignments = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    comparisons++; // Increment comparison counter
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    Swap(ref array[i], ref array[min]);
                    assignments += 2; // Each swap has 2 assignments
                }
            }
            Console.WriteLine($"Selection Sort - Comparisons: {comparisons}, Assignments: {assignments}, Total: {comparisons + assignments}");
        }

        static void InsertionSort(int[] array)
        {
            int comparisons = 0;
            int assignments = 0;
            int n = array.Length;
            for (int i = 1; i <= n - 1; i++)
            {
                int temp = array[i];
                assignments++; // Assignment of temp
                int j = i - 1;
                while (j >= 0 && array[j] > temp)
                {
                    comparisons++; // Increment comparison counter
                    array[j + 1] = array[j];
                    assignments++; // Assignment in the array
                    j--;
                }
                if (j >= 0) comparisons++; // Final comparison where condition fails
                array[j + 1] = temp;
                assignments++; // Final assignment
            }
            Console.WriteLine($"Insertion Sort - Comparisons: {comparisons}, Assignments: {assignments}, Total: {comparisons + assignments}");
        }

        static void Swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        private static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] array = new int[1000];
            Random random = new Random();
            // Fill with random numbers between 0 and 99
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(30);
            }

            int[] array2 = (int[])array.Clone();
            int[] array3 = (int[])array.Clone();
            
            BubbleSort(array);
            SelectionSort(array2);
            InsertionSort(array3);

            Console.ReadLine();
        }
    }
}

        static void Main(string[] args)
        {
            int[] array = new int[1000];
            Random random = new Random();
            // Fill with random numbers between 0 and 99
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(30);
            }

            int[] array2 = (int[])array.Clone();
            int[] array3 = (int[])array.Clone();
            
            BubbleSort(array);
            SelectionSort(array2);
            InsertionSort(array3);

            Console.ReadLine();
        }
    }
}
