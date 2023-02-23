using System;

namespace Animals;

public class StartUp
{
    public static void Main(string[] args)
    {
        
        while (true)
        {
            string animalToAdd = Console.ReadLine();
            if (animalToAdd == "Beast!")
            {
                break;
            }
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string gender = tokens[2];

            try
            {
                switch (animalToAdd)
                {
                    case "Dog":
                        Dog dog = new(name, age, gender);
                        PrintAnimal(dog);
                        Console.WriteLine(dog.ProduceSound());
                        break;
                    case "Frog":
                        Frog frog = new(name, age, gender);
                        PrintAnimal(frog);
                        Console.WriteLine(frog.ProduceSound());
                        break;
                    case "Cat":
                        Cat cat = new(name, age, gender);
                        PrintAnimal(cat);
                        Console.WriteLine(cat.ProduceSound());
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new(name, age);
                        PrintAnimal(tomcat);
                        Console.WriteLine(tomcat.ProduceSound());
                        break;
                    case "Kitten":
                        Kitten kitten = new(name, age);
                        PrintAnimal(kitten);
                        Console.WriteLine(kitten.ProduceSound());
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
    }

    public static void PrintAnimal(Animal animal)
    {
        Console.WriteLine(animal.GetType().Name);
        Console.WriteLine(animal);
    }
}