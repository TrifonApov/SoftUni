using System;
using System.Numerics;
class Problem05
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        
        int position = 0;
        ulong mask = 1;
        while (true)
        {
            string positionInput = Console.ReadLine();
            if (positionInput == "quit")
            {
                break;
            }
            else
            {
                position = int.Parse(positionInput);
            }
            string order = Console.ReadLine();

            if (order == "flip")
            {
                number = number ^ (mask << position);
            }
            if (order == "remove")
            {
                ulong left = number >> (position + 1);
                ulong right = number & ((mask << position) - 1);
                number = left << position | right;
            }
            if (order == "insert")
            {
                ulong left = number >> (position);
                ulong right = number & ((mask << position)-1);
                number = (left << 1) | 1;
                number = (number << position) | right;
            }
            if (order == "skip")
            {
                continue;
            }
        }
        Console.WriteLine(number);
    }
}
