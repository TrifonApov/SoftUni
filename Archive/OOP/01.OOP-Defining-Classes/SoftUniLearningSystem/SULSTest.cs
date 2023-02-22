namespace SoftUniLearningSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Students;
    using Students.CurrentStudents;
    using Trainers;

    class SULSTest
    {
        static void Main()
        {
            var seniorTrainer = new SeniorTrainer("Angel", "Georgiev", 30);
            seniorTrainer.CreateCourse("OOP");
            seniorTrainer.DeleteCourse("OOP");
            Console.WriteLine();
            
            var juniorTrainer = new JuniorTrainer("Ivan", "Ionkov", 23);
            juniorTrainer.CreateCourse("HQC");
            juniorTrainer.DeleteCourse("OOP");
            Console.WriteLine();
            
            var students = new List<Student>
            {
                new GraduateStudent("Pesho", "Peshov", 27, 3.68, "0000000001"),
                new GraduateStudent("Gosho", "Goshov", 23, 4.68, "0000000002"),
                new OnlineStudent("Minka", "Petrova", 18, "OOP", 4.32, "0000000003"),
                new OnlineStudent("Stamat", "Unufriev", 47, "OOP", 5.15, "0000000004"),
                new OnlineStudent("4i4o", "Tosho", 57, "OOP", 5.87, "0000000005"),
                new OnlineStudent("Baba", "Tinche", 87, "OOP", 4.00, "0000000006"),
                new OnsiteStudent("Tosho", "Toshov", 27, "HQC", 10, 6.00, "0000000017"),
                new OnsiteStudent("Min4o", "Slivov", 27, "HQC", 10, 2.00, "0000000008"),
                new OnsiteStudent("Gan4o", "Ta6kov", 27, "HQC", 10, 6.00, "0000000009"),
                new DropoutStudent("Pen4o", "Slona",19,"Q sum mnooo tap",2.01,"0000000010"),
                new DropoutStudent("Gorsho", "4epa",19,"Q sum o6te po tap",2.01,"0000000011"),
                new DropoutStudent("Rado", "6i6arkata",19,"Q 4e si peem 4algi4ka, nema se zanimavam s tiq kompotri",2.01,"0000000010")
            };

            var info = students
                .Where(s => s is CurrentStudent)
                .OrderByDescending(s => s.AverageGrade)
                .ThenBy(s => s.Number);
            foreach (var student in info)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}