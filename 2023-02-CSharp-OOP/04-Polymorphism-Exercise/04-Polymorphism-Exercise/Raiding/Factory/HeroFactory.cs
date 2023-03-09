using System;
using Raiding.Factory.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;

namespace Raiding.Factory;

public class HeroFactory : IHeroFactory
{
    public IHero Create(string heroType, string name)
    {
        switch (heroType)
        {
            case "Druid": return new Druid(name);
            case "Paladin": return new Paladin(name);
            case "Rogue": return new Rogue(name);
            case "Warrior": return new Warrior(name);
            default: throw new ArgumentException("Invalid hero!");
        }
    }
}