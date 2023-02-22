using System;

class Diamonds
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int outDash = n / 2 - 1;
        int middDash = 1;
        Console.WriteLine("{0}*{0}", new string('-', n / 2));
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('-', outDash), new string('-', middDash));
            outDash--;
            middDash += 2;
        }
        outDash = 1;
        middDash = n - 4;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('-', outDash), new string('-', middDash));
            outDash += 1;
            middDash -= 2;
        }
        Console.WriteLine("{0}*{0}", new string('-', n / 2));
    }
}
