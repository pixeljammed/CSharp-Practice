namespace Subject_Entry;

class Program
{
    static void Main(string[] args)
    {
        // Create an array for your top 5 films

        string[] films = { "ADD", "YOUR", "TOP", "5", "FILMS"};
        string inpoot = "";

        Console.WriteLine("What are your top 5 films? ");
        for (int i = 0; i < 5; i++)
        {
            inpoot = Console.ReadLine();
            films[i] = inpoot;
        }

        Array.Sort(films);
        Array.Reverse(films);
        films[4] = "Cars 2";

        foreach (string str in films)
        {
            System.Console.WriteLine(str);
        }

        Console.ReadLine();
    }
}

