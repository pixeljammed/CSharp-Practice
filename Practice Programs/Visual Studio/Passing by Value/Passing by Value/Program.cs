using System;

namespace PassingByValue
{
    class Program
    {
        static void Main()
        {
            double pay;
            pay = 2000;

            pay = CalculatePay(pay);
            Console.WriteLine(pay);
        }

        // Function to calculate deductions from pay
        static double SubtractDeductions(double pay, double percent)
        {
            return (pay * percent) / 100;
        }

        static double CalculatePay(double pay)
        {
            // Subtract tax on pay at 22%
            pay = pay - SubtractDeductions(pay, 22);
            return pay;
        }

        Console.ReadKey();
    }
}
 