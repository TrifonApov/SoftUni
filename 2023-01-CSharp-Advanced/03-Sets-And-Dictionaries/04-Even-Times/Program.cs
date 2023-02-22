using System;
using System.Collections.Generic;
using System.Linq;

int entriesCount = int.Parse(Console.ReadLine());
Dictionary<int, int> occurrences = new();

for (int i = 0; i < entriesCount; i++)
{
    int entry = int.Parse(Console.ReadLine());
    if (!occurrences.ContainsKey(entry))
    {
        occurrences.Add(entry, 1);
    }
    else
    {
        occurrences[entry]++;
    }
}

foreach (var occurrence in occurrences)
{
    if (occurrence.Value % 2 == 0)
    {
        Console.WriteLine(occurrence.Key);
        break;
    }
}