using System;

class Problem03
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}{1}{0}", new string('.', n), new string('*', n));
        int outDot = n - 2;
        int middDot = n + 2;
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', outDot), new string('.', middDot));
            outDot -= 2;
            middDot += 4;
        }
        Console.WriteLine("*{0}*{1}*{0}*", new string('.', n - 2), new string('.', n));

        outDot = n-4;
        middDot = 1;
        while(outDot>=1)
        {
            Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', outDot), new string('.', middDot), new string('.', n));
            outDot -= 2;
            middDot += 2;
        }
        outDot = n - 1;
        middDot = n;
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', outDot), new string('.', middDot));
            outDot--;
            middDot += 2;
        }
        Console.WriteLine(new string('*', n * 3));
    }
}
