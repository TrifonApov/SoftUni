using System;

class Pr01Budget
{
    static void Main()
    {
        int budget = int.Parse(Console.ReadLine());
        int weekDaysOut = int.Parse(Console.ReadLine());
        int hometown = int.Parse(Console.ReadLine());
        int rent = 150;
        int normalWeekendDays = (4 - hometown) * 2;
        int normalWeekDays = 30 - (2 * hometown + normalWeekendDays) - weekDaysOut;

        int goOutSpend = weekDaysOut * ((int)(0.03 * budget) + 10);
        int normalWeekendsSpend = normalWeekendDays * 20;
        int normalWeekDaysSpend = normalWeekDays * 10;
        int totalSpend = rent + goOutSpend + normalWeekendsSpend + normalWeekDaysSpend;
        int answer = budget - totalSpend;
        if (answer>0)
        {
            Console.WriteLine("Yes, leftover {0}.",answer);
        }
        else if (answer == 0)
        {
            Console.WriteLine("Exact Budget.");
        }
        else
        {
            Console.WriteLine("No, not enough {0}.", Math.Abs(answer));
        }

    }
}
