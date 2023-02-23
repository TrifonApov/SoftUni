using System;

namespace Animals;

public class Frog : Animal, ProduceSound
{
    public Frog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public void ProduceSound()
    {
        Console.WriteLine("Ribbit");
    }
}