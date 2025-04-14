namespace Caeser_Cipheer;

class Program
{
    static void Main(string[] args)
    {
        string choice;
        string text;
        int shift;
        char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();


        Console.WriteLine("Would you like to: \n");
        Console.WriteLine("1 - ENCODE");
        Console.WriteLine("2 - DECODE");
        choice = Console.ReadLine();

        Console.WriteLine("Enter the text to be encoded/decoded");
        text = Console.ReadLine();

        Console.WriteLine("Enter the shift amount (whole number);");
        shift = Convert.ToInt32(Console.ReadLine());
        shift %= 26;

        char[] textArray = text.ToCharArray();

        if (choice == "1")
        {
            Console.WriteLine(Encode(text, shift));
        }
        if (choice == "2")
        {
            Console.WriteLine(Decode(text, shift));
        }

        Console.ReadKey();

    }

    public static string Encode(string input, int shiftAmount)
    {
        var result = string.Empty;

        foreach (var character in input)
        {
            if (!char.IsLetter(character))
            {
                result += character;
            }
            else
            {
                var newChar = (char)(character - shiftAmount);
                if (newChar < (char.IsLower(character) ? 'a' : 'A')) newChar += (char)26;
                result += newChar;
            }
        }
        return result;
    }

    public static string Decode(string input, int shiftAmount)
    {
        var result = string.Empty;

        foreach (var character in input)
        {
            if (!char.IsLetter(character))
            {
                result += character;
            }
            else
            {
                var newChar = (char)(character + shiftAmount);
                if (newChar < (char.IsLower(character) ? 'a' : 'A')) newChar += (char)26;
                result += newChar;
            }
        }
        return result;
    }
}
