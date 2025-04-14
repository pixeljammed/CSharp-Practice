using System.ComponentModel.Design;

namespace Football_fantasy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        static void menu()
        {
            string path = "";
            bool run = true;

            while (run == true)
            {
                Console.WriteLine("1 - view existing teama");
                Console.WriteLine("2 - view team value");
                Console.WriteLine("3 - enter new player (max 5)");
                Console.WriteLine("4 - quit program");

                int menuOption = Convert.ToInt32(Console.ReadLine());
                switch (menuOption)
                {
                    case 1:
                        viewTeam(path);
                        break;
                    case 2:
                        teamValue(path);
                        break;
                    case 3:
                        StoreFootballer(path);
                        break;
                    case 4:
                        run = false;
                        break;
                }
            }
        }

        static void StoreFootballer(string path)
        {
            int playerAmount = CountTeam(path);
            if (playerAmount < 5)
            {
                Console.WriteLine("enter player name: ");
                string name = Console.ReadLine();
                File.AppendAllText(path, $"{name}\n");

                Console.WriteLine("enter player goals");
                string goals = Console.ReadLine();
                File.AppendAllText(path, $"{goals}\n");

                Console.WriteLine("enter yellow card count:");
                string yellow = Console.ReadLine();
                File.AppendAllText(path, $"{yellow}\n");

                Console.WriteLine("enter red card count");
                string red = Console.ReadLine();
                File.AppendAllText(path, $"{red}\n");
            }
            else
            {
                Console.WriteLine("max team player limit reached - reset team? [y/n] ");
                if (Console.ReadLine() == "y")
                {
                    File.WriteAllText(path, "");
                }
            }
        }



        static void viewTeam(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                string currentLine;
                while ((currentLine = file.ReadLine()) != null)
                {
                    Console.WriteLine($"Name - {currentLine}");
                    currentLine = file.ReadLine();
                    Console.WriteLine($"Goals scored - {currentLine}");
                    currentLine = file.ReadLine();
                    Console.WriteLine($"Yellow cards - {currentLine}");
                    currentLine = file.ReadLine();
                    Console.WriteLine($"Red cards - {currentLine}");
                    Console.WriteLine("");
                }
            }
        }

        static void teamValue(string path)
        {
            int goals = 0;
            int redCards = 0;
            int yellowCards = 0;

            using (StreamReader file = new StreamReader(path))
            {
                string currentLine;
                while ((currentLine = file.ReadLine()) != null)
                {
                    currentLine = file.ReadLine();
                    goals = Convert.ToInt32(currentLine);
                    currentLine = file.ReadLine();
                    yellowCards = Convert.ToInt32(currentLine);
                    currentLine = file.ReadLine();
                    redCards = Convert.ToInt32(currentLine);
                }
            }
            int value = (goals * 10) + (redCards * -5) + (yellowCards * -2);
            Console.WriteLine($"Team value = {value}");
        }

        static int CountTeam(string path)
        {
            int teamAmount = 0;
            using (StreamReader file = new StreamReader(path))
            {
                while (file.ReadLine() != null)
                {
                    teamAmount++;
                }
            }
            teamAmount /= 4;
            return teamAmount;
        }
    }
}
