using System;
using WildFarm.Factory.Interfaces;

namespace WildFarm.Factory;

public class AnimalFactory : IAnimalFactory
{
    public IAnimal Create(string heroType, string name)
    {
        switch (heroType)
        {
            case "": return new (name);
            case "": return new (name);
            case "": return new (name);
            case "": return new (name);
            default: throw new ArgumentException("");
        }
    }
}