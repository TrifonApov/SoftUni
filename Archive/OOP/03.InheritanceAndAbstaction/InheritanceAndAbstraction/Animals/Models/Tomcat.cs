namespace Animals.Models
{
    using System;

    public class Tomcat : Cat
    {
        public Tomcat(string name, int age) : base(name, age, Gender.Male)
        {
        }

        public override void SoundProduce()
        {
            Console.WriteLine("Murr!!!");
        }
    }
}