namespace Restaurant.Foods.Desserts;

public class Cake : Dessert
{
    private const decimal DessertPrice = 5.0M;
    private const double DessertGrams = 250.0;
    private const double DessertCalories = 1000.0;

    public Cake(string name) : base(name, DessertPrice, DessertGrams, DessertCalories)
    {
    }
}