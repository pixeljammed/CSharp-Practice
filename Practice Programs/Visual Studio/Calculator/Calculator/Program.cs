using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator program\n");

            string menuOption = "YOU SMELL";


            // Ask the user for two number and store them as floats
            Console.WriteLine("Enter the first number: ");
            float number1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            float number2 = float.Parse(Console.ReadLine());

            // Output the menu options
            while (menuOption != "Q")
            {
                Console.WriteLine("\nEnter the menu number of the calculation to perform: ");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Subtraction");
                Console.WriteLine("3 - Multiplication");
                Console.WriteLine("4 - Division\n");
                Console.WriteLine("Type Q to QUIT");

                // Ask for the menu option
                menuOption = Console.ReadLine();

                // Perform a subroutine based on the menu option
                if (menuOption == "1")
                {
                    Addition(number1, number2);
                }

                if (menuOption == "2")
                {
                    Subtraction(number1, number2);
                }

                if (menuOption == "3")
                {
                    Multiplication(number1, number2);
                }

                if (menuOption == "4")
                {
                    Console.Log(Divide(number1, number2));
                }

                else
                {
                    Console.WriteLine("Please choose a valid option");
                }
            }
        }

        // These procedures have two floats as parameters, does them together and outputs the result
        static float Addition(float num1, float num2)
        {
            float total = (num1 + num2);
            return total;
        }

        static float Subtraction(float num1, float num2)
        {
            float total = (num1 - num2);
            return total;
        }

        static float Multiplication(float num1, float num2)
        {
            float total = (num1 * num2);
            return total;
        }

        static float Divide(float num1, float num2)
        {
            float total = (num1 / num2);
            return total;
        }
    }
}