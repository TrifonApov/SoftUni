using System;
using System.Collections.Generic;

int entriesCount = int.Parse(Console.ReadLine());
SortedSet<string> chemicals = new();


for (int i = 0; i < entriesCount; i++)
{
    string[] entryChemicals = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    foreach (string chemical in entryChemicals)
    {
        chemicals.Add(chemical);
    }
}

Console.WriteLine(string.Join(" ", chemicals));