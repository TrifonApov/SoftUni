namespace Battleships.Ships
{
    using System;
    using Battleships;

    public class Warship : Battleship
    {
        public Warship(string name, double lengthInMeters, double volume)
            :base(lengthInMeters, name, volume)
        {
        }

        public override string Attack(Ship targetShip)
        {
            this.DestroyShip(targetShip);
            return "Victory is ours!";
        }
    }
}
