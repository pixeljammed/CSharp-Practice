namespace TPOT_4;

class Program
{
    static void Main(string[] args)
    {
        int bruh;
        int tpot = 2;
        int powa = 1;

        Console.WriteLine("Input a number:");
        bruh = Convert.ToInt32(Console.ReadLine());

        while(bruh > tpot){
            tpot = tpot * 2;
            Console.WriteLine(tpot);
            // normally i wouldn't do this butt it's fun to watch
            powa += 1;
        }
        Console.WriteLine(powa);
        Console.ReadKey();
    }
}

