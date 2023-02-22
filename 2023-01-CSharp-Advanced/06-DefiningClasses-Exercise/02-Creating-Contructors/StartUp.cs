using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();

            Person person2 = new Person(5);
            
            Person person3 = new Person("Trifon", 34);

            Console.WriteLine($"{person1.Name} - {person1.Age}");
            Console.WriteLine($"{person2.Name} - {person2.Age}");
            Console.WriteLine($"{person3.Name} - {person3.Age}");
        }
    }
}