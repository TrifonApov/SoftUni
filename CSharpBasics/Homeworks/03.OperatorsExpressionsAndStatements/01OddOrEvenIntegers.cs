using System;

class OddOrEvenIntegers
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int isOdd = int.Parse(Console.ReadLine());

        if (Math.Abs(isOdd % 2) == 1)
        {
            Console.WriteLine("Is {0} odd? - {1}", isOdd, true);
        }
        else
        {
            Console.WriteLine("Is {0} odd? - {1}", isOdd, false);
        }
    }
}
