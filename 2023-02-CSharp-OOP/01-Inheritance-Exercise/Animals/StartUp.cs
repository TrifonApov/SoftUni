using System;
using System.Collections.Generic;

namespace Animals;

public class StartUp
{
    public static void Main(string[] args)
    {
        string command = Console.ReadLine();
        List<ProduceSound> animals = new ();

        while (command != "Beast!")
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int age = int.Parse(tokens[1]);
            string gender = tokens[2];
            try
            {
                switch (command.ToLower())
                {
                    case "dog":
                        Dog dog = new(name, age, gender);
                        animals.Add(dog);
                        break;
                    case "frog":
                        Frog frog = new(name, age, gender);
                        animals.Add(frog);
                        break;
                    case "cat":
                        Cat cat = new(name, age, gender);
                        animals.Add(cat);
                        break;
                    case "tomcat":
                        Tomcat tomcat = new(name, age);
                        animals.Add(tomcat);
                        break;
                    case "kitten":
                        Kitten kitten = new(name, age);
                        animals.Add(kitten);
                        break;
                    default: break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            command = Console.ReadLine();
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.GetType().Name);
            Console.WriteLine(animal);
            animal.ProduceSound();
        }
    }
}