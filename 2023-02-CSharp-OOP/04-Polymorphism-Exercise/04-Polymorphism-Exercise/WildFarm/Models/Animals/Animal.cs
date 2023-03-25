using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals;

public abstract class Animal : IAnimal
{
    private string name;
    private double weight;
    private int foodEaten;

    protected Animal(string name, double weight)
    {
        Name = name;
        Weight = weight;
    }

    public string Name
    {
        get => name;
        private set => name = value;
    }

    public double Weight
    {
        get => weight;
        private set => weight = value;
    }

    public int FoodEaten => foodEaten;

    public abstract string ProduceSound();

    public abstract void Eat(IFood food);
}