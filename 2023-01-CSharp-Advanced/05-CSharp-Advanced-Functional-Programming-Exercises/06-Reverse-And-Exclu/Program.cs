using System;
using System.Collections.Generic;
using System.Linq;

Func<List<int>, int, List<int>> isNumberDivisible = (numbers, divider) =>
{
    List<int> result = new();

    foreach (int number in numbers)
    {
        if (number % divider != 0)
        {
            result.Add(number);
        }
    }
    return result;
};

Action<List<int>> printReversed = numbers =>
{
    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        Console.Write($"{numbers[i]} ");
    }
};

List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int divider = int.Parse(Console.ReadLine());

printReversed(isNumberDivisible(numbers, divider));