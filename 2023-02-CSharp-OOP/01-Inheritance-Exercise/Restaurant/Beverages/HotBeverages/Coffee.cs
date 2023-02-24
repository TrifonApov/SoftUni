﻿namespace Restaurant.Beverages.HotBeverages;

public class Coffee : HotBeverage
{
    private const double CoffeeMilliliters = 50.0;
    private const decimal CoffeePrice = 3.50M;
    public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMilliliters)
    {
        Caffeine = caffeine;
    }

    public double Caffeine { get; set; }
}