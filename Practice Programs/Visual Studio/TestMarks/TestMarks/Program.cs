using System;

namespace TestMarks
{
    class Program
    {
        static void Main(string[] args)
        {
            int editNum;
            int editPaper;
            string dogShirt;



            // Declare and initialise a 2D array for the test marks of Paper 1 and Paper 2
            int[,] marks = { { 34, 28, 12, 31, 18, 25 }, { 22, 15, 29, 36, 27, 19 } };

            DisplayMarks();

            Console.WriteLine("Do you want to edit student any test marks? (yes / no / all): ");
            dogShirt = Console.ReadLine();
            if (dogShirt == "yes")
            {
                Console.WriteLine("Enter the student number you'd like to edit score for");
                editNum = Convert.ToInt32(Console.ReadLine);
                Console.WriteLine("Enter the paper you'd like to edit score for");
                editPaper = Convert.ToInt32(Console.ReadLine);
                Console.WriteLine("Enter the mark you'd like to change it to");
                editPaper = Convert.ToInt32(Console.ReadLine);
            }
            if (dogShirt == "all")
            
                Console.WriteLine("Enter the mark you'd like to change it to");
                editPaper = Convert.ToInt32(Console.ReadLine);
            }

            /* TASKS:
            - Output a clear message with the student number (0-5) and the paper number (1-2)
            - Allow the user to replace a single test mark then output the updated 2D array
            - Allow the user to replace all of the test marks using another nested for loop

            Challenge: Ask the user for the number of papers and students to submit marks for. 
            The program should create an empty 2D array and then ask the user for each mark.
            */

            Console.ReadLine();
        }
        static void DisplayMarks()
        {
            for (int row = 0; row < marks.GetLength(0); row++)
            {
                for (int col = 0; col < marks.GetLength(1); col++)
                {
                    // Output the test mark
                    Console.WriteLine($"Student Number: {col} {marks[row, col]} in paper {row}");
                }
                // Create a new empty line after all the marks of a paper has been output
                Console.WriteLine("");
            }
        }
    }
}
