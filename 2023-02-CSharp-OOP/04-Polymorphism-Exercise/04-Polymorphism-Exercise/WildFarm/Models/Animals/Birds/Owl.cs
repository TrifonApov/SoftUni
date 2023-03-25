namespace WildFarm.Models.Animals.Birds;

internal class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }
}