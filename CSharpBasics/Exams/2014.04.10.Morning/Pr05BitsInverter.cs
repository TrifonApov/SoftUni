using System;

class BitsInverter
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int position = 0;
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            for (int bit = 7; bit >= 0; bit--)
            {
                position++;
                if ((step == 1) || (position % step == 1))
                {
                    number = number ^ (1 << bit);
                }
            }
            Console.WriteLine(number);
        }
    }
}
