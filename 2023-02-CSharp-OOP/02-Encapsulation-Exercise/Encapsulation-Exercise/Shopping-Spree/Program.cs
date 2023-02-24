using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new();
        List<Product> products = new();

        string[] peopleTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
        string[] productsTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

        foreach (var personToken in peopleTokens)
        {
            string[] tokens = personToken.Split("=");
            string name = tokens[0];
            decimal amountOfMoney = decimal.Parse(tokens[1]);

            try
            {
                Person person = new Person(name, amountOfMoney);
                people.Add(person);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }
        }

        foreach (var productToken in productsTokens)
        {
            string[] tokens = productToken.Split("=");
            string name = tokens[0];
            decimal cost = decimal.Parse(tokens[1]);

            try
            {
                Product product = new Product(name, cost);
                products.Add(product);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }
        }

        while (true)
        {
            string command = Console.ReadLine();
            if (command == "END")
                break;
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Person buyingPerson = people.FirstOrDefault(p => p.Name == tokens[0]);

            Console.WriteLine(buyingPerson.BuyProduct(products.FirstOrDefault(p => p.Name == tokens[1])));
        }

        foreach (Person person in people)
        {
            if (person.BagOfProduction.Any())
                Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProduction)}");
            else
                Console.WriteLine($"{person.Name} - Nothing bought");
        }
    }
}