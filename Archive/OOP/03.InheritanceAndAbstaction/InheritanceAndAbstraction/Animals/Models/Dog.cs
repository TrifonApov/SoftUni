namespace Animals.Models
{
    using System;
    using Interfaces;

    public class Dog : Animal, ISoundProducible
    {
        public Dog(string name, int age, Gender gender) : base(name, age, gender)
        {
        }

        public void SoundProduce()
        {
            Console.WriteLine("Jaff!!!");
        }
    }
}