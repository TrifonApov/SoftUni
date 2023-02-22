using System;
using System.Collections.Generic;
using System.Linq;


Func<int, int, List<int>> generateNumbersList = (start, end) =>
{
    List<int> numbers = new();
    for (int i = start; i <= end; i++)
    {
        numbers.Add(i);
    }

    return numbers;
};

int[] interval = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n=> int.Parse(n))
    .ToArray();

string command = Console.ReadLine();


List<int> numbers = generateNumbersList(interval[0], interval[1]);

Predicate<int> match;

if (command == "even")
{
    match = n => n % 2 == 0;
}
else
{
    match = n => n % 2 != 0;
}


foreach (int number in numbers)
{
    if (match(number))
    {
        Console.Write($"{number} ");
    }
}