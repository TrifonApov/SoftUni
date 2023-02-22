using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();

            int membersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < membersCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string inputName = tokens[0];
                int inputAge = int.Parse(tokens[1]);

                family.AddMember(new Person(inputName,inputAge));

            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}