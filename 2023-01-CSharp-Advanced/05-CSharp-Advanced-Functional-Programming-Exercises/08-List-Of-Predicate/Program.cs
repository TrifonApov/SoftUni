using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine());
HashSet<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

List<Predicate<int>> predicates = new();
int[] numbers = Enumerable.Range(1, n).ToArray();


foreach (int divider in dividers)
{
    predicates.Add(n => n % divider == 0);
}

List<int> result = new();
foreach (int number in numbers)
{
    bool isDivideble = true;
    foreach (Predicate<int> match in predicates)
    {
        if (!match(number))
        {
            isDivideble = false;
            break;
        }
    }

    if (isDivideble)
    {
        result.Add(number);
    }
}

Console.WriteLine(string.Join(" ", result));