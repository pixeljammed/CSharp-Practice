namespace Counting_Vowels;

class Program
{
    static void Main(string[] args)
    {
        string plug = "";
        int vowels = 0;
        int cons = 0;

        Console.WriteLine("Enter a string");
        plug = Console.ReadLine();

        for (int i = 0; i < plug.Length; i++)
        {
            if ("aeiouAEIOU".Contains(plug.Substring(i, 1)))
            {
                vowels += 1;
            }
            else
            {
                cons += 1;
            }
        }

        Console.WriteLine($"The number of vowels${vowels}");
        Console.WriteLine($"The number of non vowels${cons}");

        Console.ReadKey();
    }
}

