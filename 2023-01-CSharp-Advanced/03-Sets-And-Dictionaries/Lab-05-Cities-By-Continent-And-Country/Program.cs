using System;
using System.Collections.Generic;

int entriesCount = int.Parse(Console.ReadLine());
Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

for (int i = 0; i < entriesCount; i++)
{
    string[] entry = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string currentContinent = entry[0];
    string currentCountry = entry[1];
    string currentCity = entry[2];

    if (!continents.ContainsKey(currentContinent))
    {
        continents.Add(
            currentContinent,
            new Dictionary<string, List<string>>
            {
                {
                    currentCountry,
                    new List<string>
                    {
                        currentCity
                    }
                }
            });
    }
    else
    {
        if (!continents[currentContinent].ContainsKey(currentCountry))
        {
            continents[currentContinent].Add(
                currentCountry,
                new List<string>
                {
                    currentCity
                });
        }
        else
        {
            continents[currentContinent][currentCountry].Add(currentCity);
        }
    }
}

foreach (var continent in continents)
{
    Console.WriteLine($"{continent.Key}:");
    foreach (var country in continent.Value)
    {
        Console.WriteLine($"{country.Key} -> {string.Join(", ",country.Value)}");
    }
}

