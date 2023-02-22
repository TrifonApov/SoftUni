using System;

class BitSequenceExchange
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        long pos3Value = (long)((number >> 3) & 7);
        long pos24Value = (long)((number >> 24) & 7);
        for (int i = 24; i <= 26; i++)
        {
            number = number & (long)(~(1 << i));
        }
        for (int i = 3; i <= 5; i++)
        {
            number = number & (long)(~(1 << i));
        }
        number = (pos3Value << 24) | (pos24Value << 3) | number;
        Console.WriteLine(number);
    }
}
