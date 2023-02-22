using System;

namespace ThreeupleNS
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] secondRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] thirdRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Threeuple<string, string, string> first = new(
                $"{firstRow[0]} {firstRow[1]}", 
                firstRow[2], 
                firstRow[3]);

            Threeuple<string, int, bool> second = new(
                secondRow[0], 
                int.Parse(secondRow[1]), 
                secondRow[2] == "drunk");

            Threeuple<string, double, string> third = new(
                thirdRow[0], 
                double.Parse(thirdRow[1]), 
                thirdRow[2]);

            Console.WriteLine(first.ToString());
            Console.WriteLine(second.ToString());
            Console.WriteLine(third.ToString());
        }
    }
}