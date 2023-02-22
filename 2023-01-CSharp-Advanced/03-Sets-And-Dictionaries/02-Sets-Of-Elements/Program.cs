using System;
using System.Collections.Generic;
using System.Linq;

int[] setsCount = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
HashSet<int> firstSet = new();
HashSet<int> secondSet = new();
for (int i = 0; i < setsCount[0]; i++)
{
    firstSet.Add(int.Parse(Console.ReadLine()));
}

for (int i = 0; i < setsCount[1]; i++)
{
    secondSet.Add(int.Parse(Console.ReadLine()));
}

HashSet<int> finalSet = new();

if (setsCount[0]> setsCount[1])
{
    foreach (int i in secondSet)
    {
        if (firstSet.Contains(i))
        {
            finalSet.Add(i);
        }
    }
}
else
{
    foreach (int i in firstSet)
    {
        if (secondSet.Contains(i))
        {
            finalSet.Add(i);
        }
    }
}

Console.WriteLine(string.Join(" ", finalSet));