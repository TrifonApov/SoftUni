using System;
using System.Linq;

class BabaTinche
{
    static void Main()
    {
        int[] firstClass = Console.ReadLine().Split(' ')
            .Select(x => int.Parse(x)).ToArray();
   
        int[] bussinesClass = Array.ConvertAll(
            Console.ReadLine().Split(' '), int.Parse);
        string[] economyClass = Console.ReadLine().Split(' ');

        int[] economyClassAsInt = new int[economyClass.Length];
        for (int i = 0; i < economyClass.Length; i++)
        {
            economyClassAsInt[i] = int.Parse(economyClass[i]);
        }

        double incomes = 0;
        int normal = (firstClass[0] - firstClass[1]) * 7000;
        double discount = firstClass[1] * 0.3 * 7000;
        double food = firstClass[2] * 7000 * 0.005;
        incomes += normal + discount + food;

        normal = (bussinesClass[0] - bussinesClass[1]) * 3500;
        discount = bussinesClass[1] * 0.3 * 3500;
        food = bussinesClass[2] * 3500 * 0.005;
        incomes += normal + discount + food;

        normal = (economyClassAsInt[0] - economyClassAsInt[1]) * 1000;
        discount = economyClassAsInt[1] * 0.3 * 1000;
        food = economyClassAsInt[2] * 1000 * 0.005;
        incomes += normal + discount + food;
        Console.WriteLine((int)incomes);

        double maxFirstClass = 12 * 7000 + 12 * 7000 * 0.005;
        double maxBClass = 28 * 3500 + 28 * 3500 * 0.005;
        double maxEClass = 50 * 1000 + 50 * 1000 * 0.005;
        Console.WriteLine((int)Math.Ceiling(maxFirstClass + maxBClass + maxEClass - incomes));
    }
}
