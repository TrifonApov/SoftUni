﻿namespace Battleships.Ships
{
    using System;

    public class CargoShip : Ship
    {
        public CargoShip(string name, double lengthInMeters, double volume)
            : base(lengthInMeters, name, volume)
        {
        }
    }
}
