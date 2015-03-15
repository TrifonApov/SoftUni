using System;

class ByteParty
{
    static void Main(string[] args)
    {
        int countOfNums = int.Parse(Console.ReadLine());
        int[] numbers = new int[countOfNums];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        //n = n ^ (1 << pos);     // обръща бит-а на дадена позиция (0 -> 1 или 1 -> 0)

        //n = n & ~(1 << pos);     // прави бит-а 0-ла

        //n = n | (1 << pos);     // прави бит-а 1-ца
        while (true)
        {
            string[] comandInput = Console.ReadLine().Split();
            if (comandInput[0] == "party")
            {
                break;
            }
            string comand = comandInput[0];
            int pos = int.Parse(comandInput[1]);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (comand == "-1")
                {
                    numbers[i] ^= 1 << pos;
                }
                if (comand == "0")
                {
                    numbers[i] &= ~(1 << pos);
                }
                if (comand == "1")
                {
                    numbers[i] |= 1 << pos;
                }
            }
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}