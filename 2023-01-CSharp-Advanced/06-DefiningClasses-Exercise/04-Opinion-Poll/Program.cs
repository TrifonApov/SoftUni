namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            int peoplesCount = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < peoplesCount; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string inputName = tokens[0];
                int inputAge = int.Parse(tokens[1]);

                people.Add(new Person(inputName,inputAge));
            }

            Console.WriteLine();
            var olderТhanТhirty = people.Where(p => p.Age > 30).OrderBy(p => p.Name);
            foreach (Person person in olderТhanТhirty)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}