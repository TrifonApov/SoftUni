namespace Battleships.Ships
{
    using System;
    using Battleships;

    public class AircraftCarrier : Battleship
    {
        private int fighterCapacity;

        public AircraftCarrier(string name, double lengthInMeters, double volume, int fighterCapacity)
            : base(lengthInMeters, name, volume)
        {
            this.FighterCapacity = fighterCapacity;
        }

        public int FighterCapacity
        {
            get
            {
                return this.fighterCapacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The fighter capacity of an aircraft carrier cannot be negative.");
                }

                this.fighterCapacity = value;
            }
        }

        public override string Attack(Ship targetShip)
        {
            this.DestroyShip(targetShip);
            return "We bombed them from the sky!";
        }
    }
}
