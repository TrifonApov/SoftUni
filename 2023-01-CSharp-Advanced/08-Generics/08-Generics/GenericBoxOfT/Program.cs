using System;

namespace GenericBoxOfT;

internal class Program
{
    static void Main(string[] args)
    {
        int numberOfLine = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfLine; i++)
        {
            Box<int> box = new();
            box.Value = int.Parse(Console.ReadLine());
            Console.WriteLine(box.ToString());
        }
    }
}