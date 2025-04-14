namespace Square_Num_Loops_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int y = 0;
            int z = 0;

            while (z < 3)
            {
                x += 1;
                y += x;
                if (Math.Sqrt(y) % 1 == 0)
                {
                    Console.WriteLine(y);
                    z += 1;
                }

            }

            // IDK How I even wrote this tbh
        }
    }
}