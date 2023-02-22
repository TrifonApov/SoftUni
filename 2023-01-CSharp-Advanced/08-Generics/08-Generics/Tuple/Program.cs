using System;

namespace TupleNS;
public class Program
{
    static void Main(string[] args)
    {
        string[] firstRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] secondRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] thirdRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);



        Tuple<string, string> first = new($"{firstRow[0]} {firstRow[1]}", firstRow[2]);
        Tuple<string, int> second = new(secondRow[0], int.Parse(secondRow[1]));
        Tuple<int, double> third = new(int.Parse(thirdRow[0]), double.Parse(thirdRow[1]));

        Console.WriteLine(first);
        Console.WriteLine(second);
        Console.WriteLine(third);
    }
}