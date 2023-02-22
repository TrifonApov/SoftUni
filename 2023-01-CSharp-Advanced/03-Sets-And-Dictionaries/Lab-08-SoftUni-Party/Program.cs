using System;
using System.Collections.Generic;

HashSet<string> vipList = new HashSet<string>();
HashSet<string> regularList = new HashSet<string>();

while (true)
{
    string input = Console.ReadLine();
    if (input == "PARTY") break;

    if (input.Length == 8)
    {
        if (input[0] > 47 & input[0] < 58)
        {
            vipList.Add(input);
        }
        else
        {
            regularList.Add(input);
        }
    }
}

while (true)
{
    string input = Console.ReadLine();
    if (input == "END") break;

    if (input[0] > 47 & input[0] < 58)
    {
        vipList.Remove(input);
    }
    else
    {
        regularList.Remove(input);
    }
}

Console.WriteLine(vipList.Count + regularList.Count);
foreach (string s in vipList)
{
    Console.WriteLine(s);
}
foreach (string s in regularList)
{
    Console.WriteLine(s);
}