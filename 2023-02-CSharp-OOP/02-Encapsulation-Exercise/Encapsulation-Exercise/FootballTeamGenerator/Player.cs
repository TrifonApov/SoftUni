using System;

namespace FootballTeamGenerator;

public class Player
{
    private const int StatisticsCount = 5;

	private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    public string Name
	{
		get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            name = value;
        }
	}

    public int Endurance
    {
        get => endurance;
        private set
        {
            ValidateStatistics("Endurance", value);
            sprint = value;
        }
    }

    public int Sprint
    {
        get => sprint;
        private set
        {
            ValidateStatistics("Sprint", value);
            sprint = value;
        }
    }

    public int Dribble
    {
        get => dribble;
        private set
        {
            ValidateStatistics("Dribble", value);
            sprint = value;
        }
    }

    public int Passing
    {
        get => passing;
        private set
        {
            ValidateStatistics("Passing", value);
            sprint = value;
        }
    }

    public int Shooting
    {
        get => shooting;
        private set
        {
            ValidateStatistics("Shooting", value);
            sprint = value;
        }
    }

    // Average of all statistics
    public int Overall => (Endurance + Sprint + Dribble + Passing + Shooting) / StatisticsCount;
    
    private void ValidateStatistics(string statistic, int value)
    {
        if (value < 0 || value > 100)
            throw new ArgumentException($"{statistic} should be between 0 and 100.");
    }
}
