using System;

namespace Animals;

public class Dog : Animal, ProduceSound
{
    public Dog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public void ProduceSound()
    {
        Console.WriteLine("Woof!");
    }
}