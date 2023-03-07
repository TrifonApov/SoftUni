using System;
using System.Collections.Generic;
using System.Linq;
using BorderControl.Models;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthday> citizensAndPets = new();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 5)
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    DateTime birthDay = DateTime.ParseExact(tokens[4], "dd/MM/yyyy", null);

                    citizensAndPets.Add(new Citizen(id, name, age, birthDay));
                }
                else if (tokens[0] != "Robot") 
                {
                    string petName = tokens[1];
                    DateTime birthDay = DateTime.ParseExact(tokens[2], "dd/MM/yyyy", null);

                    citizensAndPets.Add(new Pet(petName, birthDay));
                }
            }
            int birthDayValidation = int.Parse(Console.ReadLine());
            
            foreach (var bornInYear in citizensAndPets.Where(i=>i.BirthDay.Year == birthDayValidation))
            {
                string day = bornInYear.BirthDay.Day.ToString().PadLeft(2, '0');
                string month = bornInYear.BirthDay.Month.ToString().PadLeft(2, '0');
                string year = bornInYear.BirthDay.Year.ToString().PadLeft(2, '0');

                Console.WriteLine($"{day}/{month}/{year}");
            }

        }
    }
}