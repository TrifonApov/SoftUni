using System;
using System.Collections.Generic;
using System.Linq;

double[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
Dictionary<double,int> numbersCount = new Dictionary<double, int>();

foreach (double currentNumber in numbers)
{
    if (numbersCount.ContainsKey(currentNumber))
    {
        numbersCount[currentNumber]++;
    }
    else
    {
        numbersCount.Add(currentNumber, 1);
    }
}


foreach (KeyValuePair<double, int> numberInfo in numbersCount)
{
    Console.WriteLine($"{numberInfo.Key} - {numberInfo.Value} times");
}

