using System;

namespace PizzaCalories;
public class Dough
{
    private const double baseModifier = 2.0;

	private string flourType;
	private string bakingTechnique;
    private double grams;
    private double calories;

    public Dough(string flourType, string bakingTechnique, double grams)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Grams = grams;
        calories = CalculateCalories();
    }

    public string FlourType
	{
		get => flourType;
        private set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            flourType = value;
        }
    }

    public string BakingTechnique
    {
		get => bakingTechnique;
        private set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            bakingTechnique = value;
        }
    }

    public double Grams
    {
        get => grams;
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            grams = value;
        }
    }
    public double Calories => calories;

    private double CalculateCalories()
    {
        double result = baseModifier * Grams;
        switch (FlourType.ToLower())
        {
            case "white":
                result *= 1.5;
                break;
            case "wholegrain":
                result *= 1.0;
                break;
        }
        switch (BakingTechnique.ToLower())
        {
            case "crispy":
                result *= 0.9;
                break;
            case "chewy":
                result *= 1.1;
                break;
            case "homemade":
                result *= 1.0;
                break;
        }

        return result;
    }
}
