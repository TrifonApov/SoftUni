using System;

namespace Animals;

public class Kitten : Cat, ProduceSound
{
    public Kitten(string name, int age, string gender = "Female") : base(name, age, gender)
    {
    }
}