using System;
using System.Collections.Generic;

namespace ShoppingSpree;

public class Person
{
	private string name;
	private decimal money;
	private List<Product> bagOfProducts;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new();
    }
    public string Name
	{
		get { return name; }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty");

            name = value;
        }
	}

	public decimal Money
	{
		get => money;
        private set
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative");
            
            money = value;
        }
	}

	public IReadOnlyCollection<Product> BagOfProduction => bagOfProducts.AsReadOnly();

    public string BuyProduct(Product product)
    {
        if (product.Cost > Money) 
            return $"{name} can't afford {product.Name}";
        
        bagOfProducts.Add(product);
        money-=product.Cost;
        return $"{Name} bought {product.Name}";
    }
}