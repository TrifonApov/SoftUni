using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

Func<HashSet<string>, int, HashSet<string>> filterNameByLenght = (names, n) =>
{
    foreach (string name in names)
    {
        if (name.Length > n)
        {
            names.Remove(name);
        }
    }
    return names;
};

Action<HashSet<string>> printNames = names =>
{
    foreach (string name in names)
    {
        Console.WriteLine(name);
    }
};

int n = int.Parse(Console.ReadLine());
HashSet<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToHashSet();

names = filterNameByLenght(names, n);
printNames(names);