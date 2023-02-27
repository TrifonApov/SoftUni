using System;

namespace PizzaCalories;
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string[] pizzaTokens = Console.ReadLine().Split(" ");
            Pizza pizza = new(pizzaTokens[1]);

            // create dough
            string[] doughTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dough dough = new(doughTokens[1], doughTokens[2], Double.Parse(doughTokens[3]));
            pizza.Dough = dough;


            // create toppings
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] toppingTokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Topping topping = new(toppingTokens[1], Double.Parse(toppingTokens[2]));
                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}

