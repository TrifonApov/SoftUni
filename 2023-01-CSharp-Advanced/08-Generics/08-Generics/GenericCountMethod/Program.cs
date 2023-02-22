using System;
using System.Collections.Generic;

namespace GenericCountMethod;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfLine = int.Parse(Console.ReadLine());
        //List<Box<string>> elements = new();
        List<Box<double>> elements = new();
        for (int i = 0; i < numberOfLine; i++)
        {
            //Box<string> box = new Box<string>();
            //box.Value = Console.ReadLine();

            Box<double> box = new();
            box.Value = double.Parse(Console.ReadLine());

            elements.Add(box);
        }
        //string elementToCompere = Console.ReadLine();
        double elementToCompere = double.Parse(Console.ReadLine());

        int count = 0;
        foreach (var element in elements)
        {
            if (element.CompareToGivenElement(elementToCompere))
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}