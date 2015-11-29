namespace Battleships.Ships
{
    using System;

    public abstract class Ship
    {
        private double lengthInMeters;
        private string name;
        private double volume;

        protected Ship(double lenghtInMeters, string name, double volume)
        {
            this.LengthInMeters = lenghtInMeters;
            this.Name = name;
            this.Volume = volume;
        }

        public bool IsDestroyed { get; set; }

        public double LengthInMeters
        {
            get
            {
                return this.lengthInMeters;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The length of a ship cannot be negative.");
                }

                this.lengthInMeters = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double Volume
        {
            get
            {
                return this.volume;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The volume of a ship cannot be negative.");
                }

                this.volume = value;
            }
        }
    }
}
