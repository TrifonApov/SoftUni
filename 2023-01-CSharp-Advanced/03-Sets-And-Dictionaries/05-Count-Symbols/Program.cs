using System;
using System.Collections.Generic;

string inputText = Console.ReadLine();
SortedDictionary<char,int> lettersCount = new();

foreach (char letter in inputText)
{
    if (!lettersCount.ContainsKey(letter))
    {
        lettersCount.Add(letter, 1);
    }
    else
    {
        lettersCount[letter]++;
    }
}

foreach (var letter in lettersCount)
{
    Console.WriteLine($"{letter.Key}: {letter.Value} time/s");
}