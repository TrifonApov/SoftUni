using System;

class Problem01
{
    static void Main()
    {
        string[] firstClassIn = Console.ReadLine().Split(' ');
        string[] businessClassIn = Console.ReadLine().Split(' ');
        string[] economyfirstClassIn = Console.ReadLine().Split(' ');
        double[] firstClass = Array.ConvertAll(firstClassIn, double.Parse);
        double[] businessClass = Array.ConvertAll(businessClassIn, double.Parse);
        double[] economyClass = Array.ConvertAll(economyfirstClassIn, double.Parse);
        double mealFirst = 7000 * 0.005;
        double mealBusiness = 3500 * 0.005;
        double mealEconomy = 1000 * 0.005;
        double maxIncome = 12 * 7000 + 28 * 3500 + 50 * 1000;
        maxIncome += 12 * mealFirst + 28 * mealBusiness + 50 * mealEconomy;

        double fCIncome = ((firstClass[0] - firstClass[1])* 7000) + (firstClass[1] * (7000 * 0.3)) + (mealFirst * firstClass[2]);
        double bCIncome = ((businessClass[0] - businessClass[1])* 3500) + (businessClass[1] * (3500 * 0.3)) + (mealBusiness * businessClass[2]);
        double eCIncome = ((economyClass[0] - economyClass[1])* 1000) + (economyClass[1] * (1000 * 0.3)) + (mealEconomy * economyClass[2]);
        int realIncome = (int)(fCIncome + bCIncome + eCIncome);
        
        double diff = maxIncome - realIncome;
        Console.WriteLine((realIncome));
        Console.WriteLine((diff));
    }
}
