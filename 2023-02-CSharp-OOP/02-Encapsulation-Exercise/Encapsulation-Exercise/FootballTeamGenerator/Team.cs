using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator;

public class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        Name = name;
        players = new List<Player>();
    }
    public string Name
    {
        get => name;
        private set => name = value;
    }

    public int Rating
    {
        get
        {
            int sum = 0;
            foreach (var player in players)
            {
                sum += player.Overall;
            }
            return sum / players.Count;
        }
    }


    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        Player playerToRemove = players.FirstOrDefault(p => p.Name == playerName);
        if (playerToRemove != null)
        {
            players.Remove(playerToRemove);
        }
        else
        {
            Console.WriteLine($"Player {playerName} is not in {Name} team.");
        }
    }
}