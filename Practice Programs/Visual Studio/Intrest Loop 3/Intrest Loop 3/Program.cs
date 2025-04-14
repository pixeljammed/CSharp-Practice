namespace Intrest_Loop_3;

class Program
{
    static void Main(string[] args)
    {
        double cash;
        double intrest;
        int years;

        double calc;

        Console.WriteLine("Enter the money to be invested %");
        cash = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter intrest %");
        intrest = Convert.ToDouble(Console.ReadLine());
        intrest = 1 + intrest / 100;

        Console.WriteLine("Enter number of years");
        years = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < years; i++)
        {
            cash = cash * intrest;
            Console.WriteLine(cash);
        }

        Console.ReadKey();

    }
}

