namespace WildFarm.Factory.Interfaces;

public interface IAnimalFactory
{
    IAnimal Create(string heroType, string name);
}