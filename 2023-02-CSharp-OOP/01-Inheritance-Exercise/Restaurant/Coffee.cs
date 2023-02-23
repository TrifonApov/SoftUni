namespace Restaurant;

public class Coffee : HotBeverage
{
    public Coffee(string name, double caffeine, decimal price = 3.5m, double milliliters = 50) : base(name, price, milliliters)
    {
        Caffeine = caffeine;
    }

    public double Caffeine { get; set; }

}