namespace Battleships.Interfaces
{
    using Ships;

    public interface IAttack
    {
        string Attack(Ship target);
    }
}