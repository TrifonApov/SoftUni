namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Interfaces;
    using Models.Employees;
    using Models.Sales;

    public class CompanyHierarchyMain
    {
        public static void Main()
        {
            var p1 = new Project("P1", new DateTime(2000, 1, 1));
            var p2 = new Project("P2", new DateTime(2015, 1, 1));
            var p3 = new Project("P3", new DateTime(2015, 1, 1));

            var s1 = new Product("product1", DateTime.Now.AddDays(-2), 10.56m);
            var s2 = new Product("product2", DateTime.Now.AddDays(-12), 11.56m);
            var s3 = new Product("product3", DateTime.Now.AddDays(-42), 1.56m);


            var e1 = new SalesEmployee(2, "Sales", "Employee", 2000, Department.Sales);
            e1.AddProduct(s1);
            e1.AddProducts(new[] { s2, s3, s2, s3, s2, s1 });
            e1.RemoveProduct(s2);
            e1.RemoveProducts(new[] { s2, s3 });

            var e2 = new Developer(3, "Dev", "Eloper", 2000, Department.Sales);
            e2.AddProject(p1);
            e2.AddProjects(new[] { p2, p3, p3, p2 });
            e2.SetOfProject.First(p => p.ProjectName == "P1").CloseProject();

            var manager = new Manager(1, "Pesho", "Peshov", 2000, Department.Sales);
            manager.AddEmployee(e1);
            manager.AddEmployee(e2);

            List<IPerson> allPersons = new List<IPerson>();
            allPersons.Add(e1);
            allPersons.Add(e2);
            allPersons.Add(manager);

            foreach (var person in allPersons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
