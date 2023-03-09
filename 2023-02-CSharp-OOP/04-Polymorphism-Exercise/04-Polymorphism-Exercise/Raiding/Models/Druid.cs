namespace Raiding.Models;

public class Druid : Hero
{
    private const int DefaultPower = 80;
    public Druid(string name) : base(name, DefaultPower)
    {
    }

    public override string CastAbility()
    {
        return base.CastAbility() + $" healed for {Power}";
    }
}