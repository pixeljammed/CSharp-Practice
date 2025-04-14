namespace Fibbonachi;

class Program
{
    static void Main(string[] args)
    {
        int fartDooDoo;
        int x = 0;
        int y = 1;
        int temp;

        fartDooDoo = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < fartDooDoo; i++)
        {
            temp = x;
            x = y;
            y = temp + y;

            Console.WriteLine(x);
        }

        Console.ReadKey();
    }
}

