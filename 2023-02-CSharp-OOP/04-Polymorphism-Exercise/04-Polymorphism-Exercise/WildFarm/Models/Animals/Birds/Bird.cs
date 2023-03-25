using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals.Birds;

public class Bird : Animal, IBird
{
    private double wingSize;

    public Bird(string name, double weight, double wingSize) : base(name, weight)
    {
        WingSize = wingSize;
    }

    public double WingSize
    {
        get => wingSize;
        private set => wingSize = value;
    }
}