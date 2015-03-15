using System;

class JoroTheFootballPlayer
{
    static void Main()
    {
        string isLeapYear = Console.ReadLine();
        short holidays = short.Parse(Console.ReadLine());
        short homeTown = short.Parse(Console.ReadLine());
        double totalPlays = 0;
        short weekends = 52;

        totalPlays += holidays * 0.5;
        totalPlays += homeTown;
        short normalWeekend = (short)(weekends - homeTown);
        totalPlays += normalWeekend * 2 / 3;

        if (isLeapYear == "t")
        {
            totalPlays += 3;
        }
        Console.WriteLine(Math.Round(totalPlays));

    }
}