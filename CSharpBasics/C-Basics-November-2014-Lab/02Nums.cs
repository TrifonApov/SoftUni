using System;

class Nums
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        for (int i = n; i <= m; i++)
        {
            if (i%2==1)
            {
                Console.WriteLine("{0:0.000}", Math.Pow(i,2));
            }
            else
            {
                Console.WriteLine("{0:0.000}", Math.Sqrt(i));
            }
        }
    }
}
