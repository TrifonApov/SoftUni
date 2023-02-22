using System;

class ConsoleGraphics
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}\n{0}", new string('*', 2 * n));
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('*', n / 2 + 1), new string(' ', n - 1));
        }
        Console.WriteLine("{0}\n{0}", new string('~', 2 * n));
    }
}
