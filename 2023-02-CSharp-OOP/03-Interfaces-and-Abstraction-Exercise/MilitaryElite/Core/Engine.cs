using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Core.Interfaces;
using MilitaryElite.Models;
using MilitaryElite.Models.Interfaces;

namespace MilitaryElite.Core;

public class Engine : IEngine
{
    private Dictionary<int, ISoldier> soldiers;

    public Engine()
    {
        soldiers = new Dictionary<int, ISoldier>();
    }

    public void Run()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "End") break;

            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ProcessInput(tokens);
        }
    }

    private void ProcessInput(string[] tokens)
    {
        
    }



   
}