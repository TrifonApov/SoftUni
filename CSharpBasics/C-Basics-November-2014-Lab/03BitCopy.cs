using System;

class BitCopy
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int position = int.Parse(Console.ReadLine());
        int mask = 1;
        int saveBitPos = (number >> position) & mask;
        if (saveBitPos == 0)
        {
            number &= ~(mask << 2);
        }
        else
        {
            number |= mask << 2;
        }
        Console.WriteLine(number);
    }
}
