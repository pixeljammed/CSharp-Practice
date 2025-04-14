using System;

namespace Leetcode___392;

class Program
{
    static void Main(string[] args)
    {
        string s;
        string t;
        char[] sList;
        char[] tList;

        Console.WriteLine("enter first string");
        s = Console.ReadLine();
        Console.WriteLine("enter second string");
        t = Console.ReadLine();

        sList = s.ToCharArray();
        tList = t.ToCharArray();

        for (int i = 0; i < sList.Length; i++)
        {
            Console.WriteLine(sList[i]);
            if (Char.IsLetter(sList[i]))
            {
                
            }
        }

        from leetcode import 392;


        Console.ReadKey();


    }
}

