using System;

class Pr02OddEvenSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int oddSum = 0;
        int evenSum = 0;

        for (int i = 0; i < n * 2; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (i % 2 == 0)
            {
                oddSum += number;
            }
            else
            {
                evenSum += number;
            }
        }
        if (oddSum == evenSum)
        {
            Console.WriteLine("Yes, sum={0}", oddSum);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(oddSum - evenSum));
        }
    }
}