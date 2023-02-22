using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem01
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> items = new Dictionary<int, string>
            {
                {30, "Patch"},
                {40, "Bandage"},
                {100, "MedKit"}
            };

            Queue<int> textiles = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Dictionary<string, int> createdItem = new Dictionary<string, int>();

            while (textiles.Any() && medicaments.Any())
            {
                int currentTextile = textiles.Dequeue();
                int currentMedicament = medicaments.Pop();
                int currentResources = currentTextile + currentMedicament;

                if (items.ContainsKey(currentResources))
                {
                    string currentItem = items[currentResources];
                    if (!createdItem.ContainsKey(currentItem))
                    {
                        createdItem.Add(currentItem, 1);
                    }
                    else
                    {
                        createdItem[currentItem]++;
                    }
                }
                else
                {
                    if (currentResources > 100)
                    {
                        if (createdItem.ContainsKey("MedKit"))
                            createdItem["MedKit"]++;
                        else 
                            createdItem.Add("MedKit", 1);

                        int remaining = medicaments.Pop() + currentResources - 100;
                        medicaments.Push(remaining);
                    }
                    else
                    {
                        currentMedicament += 10;
                        medicaments.Push(currentMedicament);
                    }
                }
            }

            if (!textiles.Any() && !medicaments.Any())
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (!textiles.Any())
            {
                Console.WriteLine("Textiles are empty.");
            }
            else
            {
                Console.WriteLine("Medicaments are empty.");
            }

            if (createdItem.Any())
            {
                foreach (var item in createdItem.OrderByDescending(i => i.Value).ThenBy(i => i.Key))
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }

            if (!textiles.Any() && !medicaments.Any()) return;
            Console.WriteLine(textiles.Any()
                ? $"Textiles left: {string.Join(", ", textiles)}"
                : $"Medicaments left: {string.Join(", ", medicaments)}");
        }

    }
}