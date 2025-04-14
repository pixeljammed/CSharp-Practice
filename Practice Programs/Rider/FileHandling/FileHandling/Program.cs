namespace FileHandling;
using System;
using System.IO;

class FantasyFootball
{
    const string filePath = "team.txt";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine(" Football Team Manager");
            Console.WriteLine("1. Add New Player");
            Console.WriteLine("2. View Team");
            Console.WriteLine("3. View Team's Current Value");
            Console.WriteLine("4. Quit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewPlayer();
                    break;
                case "2":
                    ViewTeam();
                    break;
                case "3":
                    ViewTeamValue();
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }

    static void AddNewPlayer()
    {
        var team = LoadTeam();

        if (team.Count >= 5)
        {
            Console.WriteLine("Team is full (max 5 players)");
            return;
        }

        Console.Write("Enter player's name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goals scored: ");
        int goals = int.Parse(Console.ReadLine());
        Console.Write("Enter number of yellow cards: ");
        int yellowCards = int.Parse(Console.ReadLine());
        Console.Write("Enter number of red cards: ");
        int redCards = int.Parse(Console.ReadLine());

        string playerData = $"{name}:{goals}:{yellowCards}:{redCards}";
        team.Add(playerData);

        SaveTeam(team);
        Console.WriteLine("Player added successfully!");
    }

    static void ViewTeam()
    {
        var team = LoadTeam();

        Console.WriteLine("View Team");
        for (int i = 0; i < team.Count; i++)
        {
            string[] parts = team[i].Split(':');
            string name = parts[0];
            string goals = parts[1];
            string yellowCards = parts[2];
            string redCards = parts[3];

            Console.WriteLine($"{i + 1}. {name} - Goals: {goals}, Yellow Cards: {yellowCards}, Red Cards: {redCards}");
        }
    }

    static void ViewTeamValue()
    {
        var team = LoadTeam();
        int totalValue = 0;

        foreach (string playerData in team)
        {
            string[] parts = playerData.Split(':');
            int goals = int.Parse(parts[1]);
            int yellowCards = int.Parse(parts[2]);
            int redCards = int.Parse(parts[3]);

            totalValue += (goals * 10) - (yellowCards * 2) - (redCards * 5);
        }

        Console.WriteLine($"The team's current value is: {totalValue} points.");
    }

    static List<string> LoadTeam()
    {
        List<string> team = new List<string>();

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            team.AddRange(lines);
        }

        return team;
    }

    static void SaveTeam(List<string> team)
    {
        File.WriteAllLines(filePath, team);
    }
}
