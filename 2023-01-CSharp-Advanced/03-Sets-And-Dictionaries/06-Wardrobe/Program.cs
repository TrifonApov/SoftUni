using System;
using System.Collections.Generic;

int entriesCount = int.Parse(Console.ReadLine());
Dictionary<string, Dictionary<string, int>> wardrobe = new();

for (int i = 0; i < entriesCount; i++)
{
    string[] entry = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries);
    string color = entry[0];
    string[] clothes = entry[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

    if (!wardrobe.ContainsKey(color))
    {
        wardrobe.Add(color,new Dictionary<string, int>());
        foreach (string pieceOfClothing in clothes)
        {
            if (!wardrobe[color].ContainsKey(pieceOfClothing))
            {
                wardrobe[color].Add(pieceOfClothing,1);
            }
            else
            {
                wardrobe[color][pieceOfClothing]++;
            }
        }
    }
    else
    {
        foreach (string pieceOfClothing in clothes)
        {
            if (!wardrobe[color].ContainsKey(pieceOfClothing))
            {
                wardrobe[color].Add(pieceOfClothing,1);
            }
            else
            {
                wardrobe[color][pieceOfClothing]++;
            }
        }
    }
}

string[] pieceOfClothingToFind = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
foreach (var color in wardrobe)
{
    Console.WriteLine($"{color.Key} clothes:");
    foreach (var pieceOfClothing in color.Value)    
    {
        if (color.Key == pieceOfClothingToFind[0] && pieceOfClothing.Key == pieceOfClothingToFind[1])
        {
            Console.WriteLine($"* {pieceOfClothing.Key} - {pieceOfClothing.Value} (found!)");
        }
        else
        {
            Console.WriteLine($"* {pieceOfClothing.Key} - {pieceOfClothing.Value}");
        }
    }
}