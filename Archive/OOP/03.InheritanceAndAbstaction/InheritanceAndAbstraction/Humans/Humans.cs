namespace Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    class Humans
    {
        static void Main()
        {
            var students = new List<Student>
            {
                new Student("Pesho", "Peshov", 54383),
                new Student("Angel", "Angelov", 543383),
                new Student("Boris", "Borisov", 4383),
                new Student("Boris", "Petrov", 5483),
                new Student("Krum", "Sashov", 383),
                new Student("Ilarion", "Spiridonov", 12354383),
                new Student("Chaika", "Belejkova", 52344383),
                new Student("Minka", "Spasova", 5438563),
                new Student("Trendafil", "Kanemska", 5438783),
                new Student("MyName", "IsMuerte", 5435583)
            };

            var workers = new List<Worker>
            {
                new Worker("Hari", "Peshov", 54383m, 5),
                new Worker("Bari", "Angelov", 12323.23m, 20),
                new Worker("Mari", "Borisov", 4323.32m, 3),
                new Worker("Zari", "Petrov", 100.0m,2),
                new Worker("Dari", "Sashov", 4324.23m, 6),
                new Worker("Kari", "Spiridonov", 1234.56m,8),
                new Worker("Pari", "Belejkova", 12252.50m, 18),
                new Worker("Fari", "Spasova", 200.20m, 6),
                new Worker("Tari", "Kanemska", 852.25m, 7),
                new Worker("MyName", "IsMuerte", 1358.20m, 3)
            };

            //var sortedStudents = students.OrderBy(s => s.FacultyNumber);
            //foreach (var student in sortedStudents)
            //{
            //    Console.WriteLine(student.ToString());
            //}

            //var sortedWorkers = workers.OrderBy(w => w.MoneyPerHour());
            //foreach (var worker in sortedWorkers)
            //{
            //    Console.WriteLine(worker.ToString());
            //}

            var allHumans = new List<Human>();
            students.ForEach(s => allHumans.Add(s));
            workers.ForEach(w => allHumans.Add(w));
            var sortedHumans = allHumans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName);

            foreach (var human in sortedHumans)
            {
                Console.WriteLine(human.ToString());
            }
        }
    }
}
