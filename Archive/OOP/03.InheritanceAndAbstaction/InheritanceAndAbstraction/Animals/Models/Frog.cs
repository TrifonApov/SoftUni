namespace Animals.Models
{
    using System;
    using Interfaces;

    public class Frog : Animal, ISoundProducible
    {
        public Frog(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public void SoundProduce()
        {
            Console.WriteLine("Croak!");
        }
    }
}