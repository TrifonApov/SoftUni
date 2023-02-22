// side | user
// user -> side
//Lighter | Royal
//Darker | DCay
//John Johnys -> Lighter
//DCay -> Lighter
//Lumpawaroo

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

string input = Console.ReadLine();
Dictionary<string, SortedSet<string>> forces = new();

while (input != "Lumpawaroo")
{
    // get input data
    string[] inputData;
    string side;
    string userName;
    string command;
    if (input.Contains('|'))
    {
        inputData = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
        userName = inputData[1].Trim();
        side = inputData[0].Trim();
        command = "|";
    }
    else
    {
        inputData = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
        userName = inputData[0].Trim();
        side = inputData[1].Trim();
        command = "->";
    }

    // fill the dictionary
    if (command == "|")
    {

        if (!forces.ContainsKey(side))
        {
            forces.Add(side, new SortedSet<string> { userName });
        }
        else
        {
            forces[side].Add(userName);
        }
    }
    else if (forces.ContainsKey(side))
    {
        foreach (var force in forces)
        {
            if (force.Key != side)
            {
                force.Value.Remove(userName);
            }
            else
            {
                force.Value.Add(userName);
                Console.WriteLine($"{userName} joins the {side} side!");
            }
        }
    }
    else
    {
        foreach (var force in forces)
        {

            if (force.Key != side)
            {
                force.Value.Remove(userName);
            }
        }
        forces.Add(side, new SortedSet<string> { userName });
        Console.WriteLine($"{userName} joins the {side} side!");
    }


    input = Console.ReadLine();
}

// Print result
foreach (var force in forces.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
{
    if (force.Value.Count > 0)
    {
        Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Count}");
        foreach (string user in force.Value)
        {
            Console.WriteLine($"! {user}");
        }
    }

}