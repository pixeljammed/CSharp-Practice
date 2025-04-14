namespace RecursiveFunction;

class Program
{
    static void Main(string[] args)
    {
        // First Number
        Console.WriteLine("Enter a number");
        int poo = Convert.ToInt32(Console.ReadLine());
        
        // Second Number
        Console.WriteLine("Enter a number");
        int pee = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Your Number: " + poo);
        Console.WriteLine("Factorial: " + Factorial(poo));
        Console.WriteLine("Triangular: " + Triangular(poo));
        Console.WriteLine("Fibbonachi: " + FastFibbonachi(poo));
        
        Console.WriteLine("Greatest Common Divisor: " + Fibbonachi(poo));
        
        
        Console.ReadLine();
    }

    static int Factorial(int num)
    {
        int result = 1;
        if (num == 1) return 1;
        else
        {
            result = num * Factorial(num - 1);
        }
        return result;
    }

    static int Triangular(int num)
    {
        if (num == 0 || num == 1) return 1;
        else
        {
            return num + Triangular(num - 1);
        }
    }

    // static int calculatePower(int num, int pow)
    // {
    //     int result = num;
    // }

    static int Fibbonachi(int num)
    {
        Console.WriteLine($"Tried {num}...");
        if (num == 0 || num == 1) return 1;
        else
        {
            return Fibbonachi(num - 1) + Fibbonachi(num - 2);
        }
    }

    static Int128 FastFibbonachi(int num)
    {
        List<Int128> fib = new List<Int128> { 1, 2 };
        if (num == 0 || num == 1) return 1;
        else
        {
            for (int i = 2; i < num; i++)
            {
                fib.Add(fib[i - 1] + fib[i - 2]);
            }

            return fib[num - 1];
        }
        
        

    }
    
    static int GreatestCommonDivisor(int num1, int num2)
    {
        if (num2 == 0)
        {
            return num1;
        }
        else
        {
            return GreatestCommonDivisor(num2, num1 % num2);
        }
    }
}

