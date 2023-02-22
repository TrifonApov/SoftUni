using System;
using System.Linq;

int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[] largest3 = numbers.OrderByDescending(x => x).Take(3).ToArray();
Console.WriteLine(string.Join(" ", largest3));