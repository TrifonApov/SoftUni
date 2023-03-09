namespace Raiding.Models;

public class Warrior : Hero
{
    private const int DefaultPower = 100;
    public Warrior(string name) : base(name, DefaultPower)
    {
    }
    public override string CastAbility()
    {
        return base.CastAbility() + $" hit for {Power} damage";
    }
}