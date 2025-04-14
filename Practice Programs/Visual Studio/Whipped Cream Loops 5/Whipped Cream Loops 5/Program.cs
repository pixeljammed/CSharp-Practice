namespace Whipped_Cream_Loops_5;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("welcome to the lamest program ever");
        // this is just basic math the answer is 25 seconds

        int x = 0;

        for (int i = 100; i >= 50; i-=2)
        {
            x += 1;
            Console.WriteLine($"THIS IS THE {x}TH SECOND - CAN IS {i}% full");
            Thread.Sleep(100);
        }
        Console.WriteLine("it is done");
        Console.ReadKey();
    }
}

