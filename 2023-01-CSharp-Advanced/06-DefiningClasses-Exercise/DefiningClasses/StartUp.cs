using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new();
            person.Name = "Peter";
            person.Age = 20;

            Person person2 = new()
            {
                Name = "George",
                Age = 18
            };

            Console.WriteLine($"{person.Name} is {person.Age} years old");
        }
    }
}