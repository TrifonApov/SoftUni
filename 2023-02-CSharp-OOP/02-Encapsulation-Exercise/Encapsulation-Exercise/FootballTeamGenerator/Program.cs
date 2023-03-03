using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FootballTeamGenerator;

public class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
                break;

            try
            {
                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                switch (command.ToLower())
                {
                    case "team":
                        teams.Add(new Team(tokens[1]));
                        break;
                    case "add":
                        string teamName = tokens[1];
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        if (!teams.Any(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams.First(t => t.Name == teamName).AddPlayer(player);
                        }
                        break;
                    case "remove":
                        Team teamToRemovePlayer = teams.First(t => t.Name == tokens[1]);
                        teamToRemovePlayer.RemovePlayer(tokens[2]);
                        break;
                    case "rating":
                        Team team = teams.First(t => t.Name == tokens[1]);
                        Console.WriteLine($"{team.Name} - {team.Rating}");
                        break;
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}