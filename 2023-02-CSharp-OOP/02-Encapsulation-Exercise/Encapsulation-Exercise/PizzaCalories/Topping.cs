using System;

namespace PizzaCalories;

public class Topping
{
    private const double baseModifier = 2.0;

    private double grams;
    private string type;
    private double caloriesPerGram;
    private double calories;

    public Topping(string type, double grams)
    {
        Type = type;
        Grams = grams;
        caloriesPerGram = CalculateCaloriesPerGram();
        calories = caloriesPerGram * grams;
    }
    
    public string Type
    {
        get => type;
        private set
        {
            if (value.ToLower() != "meat" &&
                value.ToLower() != "veggies" &&
                value.ToLower() != "cheese" &&
                value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public double Grams
    {
        get { return grams; }
        private set
        {
            if (value < 0 || value > 50)
            {
                throw new ArgumentException($"{Type} weight should be in the range [1..50].");
            }
            grams = value;
        }
    }

    public double CaloriesPerGram => caloriesPerGram;
    public double Calories => calories;

    private double CalculateCaloriesPerGram()
    {
        double result = baseModifier;
        
        switch (Type.ToLower())
        {
            case "meat": result *= 1.2; break;
            case "veggies": result *= 0.8; break;
            case "cheese": result *= 1.1; break;
            case "sauce": result *= 0.9; break;
        }

        return result;
    }
}

