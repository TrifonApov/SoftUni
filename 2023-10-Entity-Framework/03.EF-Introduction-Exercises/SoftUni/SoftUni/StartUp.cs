using System.Diagnostics.Metrics;
using System.Text;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new();

            // Problem 03
            // Console.WriteLine(GetEmployeesFullInformation(context));

            // Problem 04
            // Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            // Problem 05
            // Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            // Problem 06
            Console.WriteLine(AddNewAddressToEmployee(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.Id)
                .ToList();

            StringBuilder result = new();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return result.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();
            
            StringBuilder result = new();
            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }
            return result.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary
                })
                .OrderBy(e=>e.Salary)
                .ThenByDescending(e=>e.FirstName)
                .ToList();

            //Console.WriteLine(employees.ToQueryString());
            
            StringBuilder result = new();
            foreach (var employee in employees)
            {
                result.AppendLine(
                    $"{employee.FirstName} {employee.LastName} from {employee.Name} = {employee.Salary:F2}");
            }
            
            return result.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new ()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            var nakov = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");
            if (nakov != null)
            {
                nakov.Address = address;
            }
            context.SaveChanges();

            var adresses = context.Employees
                .Select(e => new
                {
                    e.Address,
                    e.AddressId
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();
            StringBuilder result = new();
            foreach (var employee in adresses)
            {
                result.AppendLine(employee.Address.AddressText);
            }
            return result.ToString();
        }
    }
}