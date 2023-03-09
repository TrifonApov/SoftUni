using System;
using System.Collections.Generic;
using System.Linq;
using Raiding.Core.Interfaces;
using Raiding.Factory.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

namespace Raiding.Core;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private IHeroFactory heroFactory;

    public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroFactory = heroFactory;
    }

    public void Run()
    {
        int numberOfHeroes = int.Parse(reader.ReadLine());
        ICollection<IHero> heroes = new List<IHero>();

        while(true)
        {
            if (heroes.Count == numberOfHeroes)
            {
                break;
            }
            try
            {
                string currentName = reader.ReadLine();
                string currentType = reader.ReadLine();
                IHero currentHero = heroFactory.Create(currentType, currentName);
                heroes.Add(currentHero);
                writer.WriteLine(currentHero.CastAbility());

            }
            catch (ArgumentException exception)
            {
                writer.WriteLine(exception.Message);
            }

        }
        
        int bossHealth = int.Parse(reader.ReadLine());
        int totalDamage = heroes.Sum(h => h.Power);
        
        writer.WriteLine(totalDamage >= bossHealth 
            ? "Victory!" 
            : "Defeat...");
    }
}