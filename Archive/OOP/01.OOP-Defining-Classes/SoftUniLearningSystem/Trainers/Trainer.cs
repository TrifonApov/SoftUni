namespace SoftUniLearningSystem.Trainers
{
    using System;

    public class Trainer : Person
    {
        public Trainer(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
        }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine("{0}.{1}({3}) created course \"{2}\"",
                this.FirstName.Substring(0, 1),
                this.LastName,
                courseName,
                this.GetType().Name);
        }

        public void DeleteCourse(string courseName)
        {
            if (this.GetType().Name == "SeniorTrainer")
            {
                Console.WriteLine("{0}.{1}({3}) deleted course \"{2}\"",
                this.FirstName.Substring(0, 1),
                this.LastName,
                courseName,
                this.GetType().Name);
            }
            else
            {
                Console.WriteLine("{0}.{1} is not authorized to delete courses",
                    this.FirstName.Substring(0, 1),
                    this.LastName);
            }

        }
    }
}