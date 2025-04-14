using System.Text.RegularExpressions;

namespace Palindrome;

class Program
{
    static void Main(string[] args)
    {
        string s;
        string check1;
        string check2;
        bool pally = true;

        Console.WriteLine("enter a string");
        s = Console.ReadLine();
        s = Regex.Replace(s, @"\s", string.Empty);
        for (int i = 0; i < s.Length; i++)
        {
            check1 = s.Substring(i, 1);
            check2 = s.Substring((s.Length-i)-1, 1);
            if (check1 != check2)
            {
                pally = false;
            }
        }
        if (pally == true)
        {
            Console.WriteLine($"yes, the string {s} is a palindrome!");
        }
        else
        {
            Console.WriteLine($"no, the string {s} is NOT a palindrom :-(");
        }
        Console.ReadKey();
    }
}

