namespace Colored_Triangles;

class Program
{
    static void Main(string[] args)
    {
        string inpoot = "POO";
        string inpoot2 = "";
        const string cool = "RGB";
        string temp = cool;
        string checky = "RR";

        while ((inpoot.Length >= 2 && (inpoot.Length <= 10)) == false)
        {
            Console.WriteLine("enter a max 10 string of the values \"R\" \"G\" \"B\" without spaces");
            inpoot = Console.ReadLine();
            Console.WriteLine(inpoot.Length > 0 && (inpoot.Length <= 10));
        }

        while (inpoot.Length != 1)
        {
            for (int i = 0; i < inpoot.Length; i++)
            {
                checky = inpoot.Substring(2, i);
                if (checky.Substring(0, 1) == checky.Substring(1, 1))
                {
                    inpoot2 += checky.Substring(0, 1);
                }
                else
                {
                    char[] MyChar = { Convert.ToChar(checky.Substring(0, 1)), Convert.ToChar(checky.Substring(1, 1)) };
                    inpoot2 += temp.TrimStart(MyChar);
                    temp = cool;
                }

            }

            inpoot = inpoot2;

        }
        Console.WriteLine(inpoot+"is the last value");
        Console.ReadKey();
    }
}

