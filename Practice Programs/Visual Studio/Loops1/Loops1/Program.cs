namespace Loops1;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 32; i < 128; i++)
        {
            Console.WriteLine(Convert.ToChar(i));
        }
        Console.ReadKey();
    }
}

