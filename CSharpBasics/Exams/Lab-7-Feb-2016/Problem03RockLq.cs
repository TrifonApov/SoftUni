using System;

class RockLq
{
    static void Main()
    {
        
        int n = int.Parse(Console.ReadLine());
        int width = n * 3;
        int height = n * 2;

        Console.WriteLine("{0}{1}{0}",
            new string('.', n),
            new string('*', n));
        int innerDots = n + 2;
        int outerDots = n - 2;
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",
                new string('.', outerDots),
                new string('.', innerDots));
            outerDots -= 2;
            innerDots += 4;
        }
        Console.WriteLine("*{0}*{1}*{0}*",
            new string('.', n - 2),
            new string('.', n));

        outerDots = n - 4;
        innerDots = 1;
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*",
                new string('.', outerDots),
                new string('.', innerDots),
                new string('.', n));
            outerDots -= 2;
            innerDots += 2;
        }
        outerDots = n - 1;
        innerDots = n;
        for (int i = 0; i < n - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",
                new string('.', outerDots),
                new string('.', innerDots));
            outerDots--;
            innerDots += 2;
        }
        Console.WriteLine(new string('*', 3*n));
    }
}
