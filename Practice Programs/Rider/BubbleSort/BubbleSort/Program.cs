using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void BubbleSort(int[] array)
        {
            bool swapped;
            for (int i = 0; i < array.Length; i++)
            {
                swapped = false;
                for (int j = 0; j < UPPER; j++)
                {
                    
                }
            }
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
            int[] array = new int[50];
            Random random = new Random();
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(100);
            }

            Print(array);
            Console.WriteLine("Bubble Sort: ");
            BubbleSort(array);
            Print(array);

            Console.ReadLine();
        }
    }
}
