namespace Battleships.Ships.Battleships
{
    using Interfaces;

    public abstract class Battleship : Ship, IAttack
    {
        protected Battleship(double lenghtInMeters, string name, double volume) : base(lenghtInMeters, name, volume)
        {
        }

        public abstract string Attack(Ship targetShip);

        protected void DestroyShip(Ship targetShip)
        {
            targetShip.IsDestroyed = true;
        }
    }
}