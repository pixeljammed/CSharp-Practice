using System;
using System.Xml.Schema;
using Blackjack;

namespace Blackjack;

using static Globals;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        Menu();

        if (balance < 100)
        {
            DisplayStats();
        }
    }

    static void Menu()
    {
        Console.Clear();

        Typewrite("WELCOME TO MILO'S CRAPPY CARD GAMES \n \n", 50);
        Thread.Sleep(500);

        Typewrite("ENTER OPTION:          \n", 50);
        Console.WriteLine("1 - Play BLACKJACK     ");
        Console.WriteLine("2 - View Stats     ");
        Console.WriteLine("3 - Play YYY     ");
        Console.WriteLine("4 - Exit     ");
        Console.WriteLine("Enter number 1-4: \n \n");

        int choice;

        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
        }

        switch (choice)
        {
            case 1:
                Console.Clear();
                BlackjackGame blackjack = new BlackjackGame();
                blackjack.Play();
                break;
            case 2:
                Typewrite("UNIMPLEMENTED", 10);
                Menu();
                break;
            case 3:

                Menu();
                break;
            case 4:
                Typewrite("Bye bye!", 10);
                break;
        }
    }

    static void Typewrite(string message, int delay)
    {
        for (int i = 0; i < message.Length; i++)
        {
            Console.Write(message[i]);
            System.Threading.Thread.Sleep(delay);
        }
    }

    static void DisplayStats()
    {
        // Lost all money
        if (balance < 100)
        {
            Typewrite("YOU LOST ALL YOUR MONEY!!! Next time stick to counter-strike cases eh? \n \n", 30);
        }

        Console.WriteLine($"STATS:");
        Console.WriteLine($"W's: {wins}");
        Console.WriteLine($"L's: {games - wins}");
        Console.WriteLine($"Total Games Played: {games}");
        Console.WriteLine($"Win/Loss Ratio: {Convert.ToDouble(wins / games)}");

        Console.ReadLine();
    }
}