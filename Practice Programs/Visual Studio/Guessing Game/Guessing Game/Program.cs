namespace Guessing_Game;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int ans = rnd.Next(1, 100);
        int guess;
        int guessCount = 0;

        Console.WriteLine("guess my number from 1-100 teehee");
        guess = Convert.ToInt32(Console.ReadLine());

        while (guess != ans)
        {
            Console.WriteLine("lol your wrong. guess again noob.");
            if (guess > ans)
            {
                Console.WriteLine("the number is lower");
            }
            else
            {
                Console.WriteLine("the number is higher");
            }
            guess = Convert.ToInt32(Console.ReadLine());
            guessCount += 1;
        }

        Console.WriteLine("YOU GUESSED IT WEL DONE U DONNY");
        Console.WriteLine($"that took you {guessCount} guesses lol");

        Console.ReadKey();

    }
}

