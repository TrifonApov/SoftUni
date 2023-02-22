using System;

namespace CustomRandomList;

public class StartUp
{
    static void Main(string[] args)
    {
        RandomList list = new RandomList
        {
            "edno",
            "dve",
            "tri",
            "chetiri",
            "pet",
            "shest",
            "sedem",
            "osem"
        };

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(list.RandomString());
        }
    }
}