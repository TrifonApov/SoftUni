namespace Animals.Models
{
    using System;
    using Interfaces;

    public class Cat : Animal, ISoundProducible
    {
        public Cat(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public virtual void SoundProduce()
        {
            Console.WriteLine("Myew!");
        }
    }
}