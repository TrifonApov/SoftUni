using Raiding.Models.Interfaces;

namespace Raiding.Models;

public abstract class Hero : IHero
{
    private string name;
    private int power;

    public Hero(string name, int power)
    {
        Name = name;
        Power = power;
    }

    public string Name
    {
        get => name;
        private set => name = value;
    }

    public int Power
    {
        get => power;
        private set => power = value;
    }

    public virtual string CastAbility()
    {
        return $"{GetType().Name} - {Name}";
    }
}