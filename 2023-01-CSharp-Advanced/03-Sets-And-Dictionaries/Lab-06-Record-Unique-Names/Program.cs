using System;
using System.Collections.Generic;

int entriesCount = int.Parse(Console.ReadLine());
HashSet<string> set = new HashSet<string>();
for (int i = 0; i < entriesCount; i++)
{
    set.Add(Console.ReadLine());
}

foreach (string s in set)
{
    Console.WriteLine(s);
}