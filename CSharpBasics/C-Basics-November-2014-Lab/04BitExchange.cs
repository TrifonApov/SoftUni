using System;

class BitSwap
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        int pos3Value = (int)((number >> 3) & 1);
        int pos24Value = (int)((number >> 24) & 1);
        if (pos3Value==0)
        {
            number &= ~(1 << 24);
        }
        else
        {
            number |= 1 << 24;
        }
        if (pos24Value==0)
        {
            number &= ~(1 << 3);
        }
        else
        {
            number |= 1 << 3;
        }
        Console.WriteLine(number);
    }
}
