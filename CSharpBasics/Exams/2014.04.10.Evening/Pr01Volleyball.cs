using System;

class Pr01Volleyball
{
    static void Main()
    {
        string isLeap = Console.ReadLine();
        double holidays = double.Parse(Console.ReadLine());
        double hometown = double.Parse(Console.ReadLine());
        double totalPlays = 0;

        if (isLeap == "normal")
        {
            totalPlays = holidays * 2 / 3  + hometown + (48 - hometown) * 3 / 4;
        }
        else
        {
            totalPlays = (holidays * 2 / 3 + hometown + (48 - hometown) * 3 / 4) * 1.15;
        }
        Console.WriteLine((int)totalPlays);

    }
}