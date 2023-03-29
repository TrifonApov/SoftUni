using System;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private const int TeamMinCapacity = 15;

        private FootballPlayer player;
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("Gerrard", 8, "Midfielder");
            team = new FootballTeam("Liverpool", TeamMinCapacity);
        }

        [Test]
        public void Test1_Constructor()
        {
            FootballTeam newFootballTeam = new FootballTeam("CSKA", 20);

            Assert.That("CSKA", Is.EqualTo(newFootballTeam.Name));
            Assert.That(20, Is.EqualTo(newFootballTeam.Capacity));
            Assert.That(0, Is.EqualTo(newFootballTeam.Players.Count));
        }

        [Test]
        public void Test2_CreateTeamWithEmptyNameShouldThrow()
        {
            FootballTeam newEmptyTeam;

            ArgumentException ex = Assert.Throws<ArgumentException>(() => { newEmptyTeam = new FootballTeam(String.Empty, 20); });

            Assert.That(ex.Message, Is.EqualTo("Name cannot be null or empty!"));
        }

        [Test]
        public void Test3_CreateTeamWithNullNameShouldThrow()
        {
            FootballTeam newNullTeam;

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {
                newNullTeam = new FootballTeam(null, 20);
            });

            Assert.That(exception.Message, Is.EqualTo("Name cannot be null or empty!"));
        }

        [Test]
        public void Test4_CreateTeamWithCapacityLessThan15ShouldThrow()
        {
            FootballTeam newNullTeam;

            ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            {
                newNullTeam = new FootballTeam("Liverpool", 14);
            });

            Assert.That(exception.Message, Is.EqualTo("Capacity min value = 15"));
        }

        [Test]
        public void Test5_AddNewPlayer()
        {
            string result = team.AddNewPlayer(player);

            Assert.That(1, Is.EqualTo(team.Players.Count));
            Assert.That(team.Players[0].Name, Is.EqualTo("Gerrard"));
            Assert.That(result, Is.EqualTo($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}"));

        }

        [Test]
        public void Test6_PickPlayer()
        {
            team.AddNewPlayer(player);
            FootballPlayer pickedPlayer = team.PickPlayer("Gerrard");

            Assert.That(pickedPlayer.Name, Is.EqualTo("Gerrard"));
        }

        [Test]
        public void Test7_PickNotExistingPlayerShouldReturnNull()
        {
            team.AddNewPlayer(player);
            FootballPlayer pickedPlayer = team.PickPlayer("Stoichkov");

            Assert.That(pickedPlayer, Is.Null);
        }

        [Test]
        public void Test8_PlayerScore()
        {
            team.AddNewPlayer(player);
            string result = team.PlayerScore(8);

            Assert.That(player.ScoredGoals, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo($"{player.Name} scored and now has {player.ScoredGoals} for this season!"));

        }

        [Test]
        public void Test9_AddMorePlayersThanCapacityShouldThrow()
        {
            string result;
            for (int i = 1; i <= TeamMinCapacity; i++)
            {
                team.AddNewPlayer(new FootballPlayer(i.ToString(), i, "Forward"));
            }

            result = team.AddNewPlayer(new FootballPlayer("16", 16, "Goalkeeper"));
            
            Assert.That(result, Is.EqualTo("No more positions available!"));

        }
    }
}