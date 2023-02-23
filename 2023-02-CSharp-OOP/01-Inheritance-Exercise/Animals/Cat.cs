using System;

namespace Animals;

public class Cat : Animal, ProduceSound
{
    public Cat(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public void ProduceSound()
    {
        Console.WriteLine("Meow meow");
    }
}