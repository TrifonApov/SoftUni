namespace Persons
{
    using System;

    class PersonsMain
    {
        static void Main()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Person pesho = new Person(name, age);

            Person pesho2 = new Person(name, age, email);
            Console.WriteLine(pesho.ToString());
            Console.WriteLine(pesho2.ToString());
        }
    }
}
