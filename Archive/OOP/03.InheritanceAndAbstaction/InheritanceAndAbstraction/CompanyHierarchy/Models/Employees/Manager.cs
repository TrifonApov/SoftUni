namespace CompanyHierarchy.Models.Employees
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enums;
    using Interfaces;

    public class Manager : Employee, IManager
    {
        private ICollection<IRegularEmployee> employeesList;

        public Manager(int id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName, salary, department)
        {
            this.EmployeesList = new List<IRegularEmployee>();
        }

        public ICollection<IRegularEmployee> EmployeesList
        {
            get { return this.employeesList; }
            set { this.employeesList = value; }
        }

        public void AddEmployee(IRegularEmployee employee)
        {
            this.EmployeesList.Add(employee);
        }

        public void AddEmployees(IRegularEmployee[] employees)
        {
            foreach (IRegularEmployee employee in employees)
            {
                this.EmployeesList.Add(employee);
            }
        }

        public void RemoveEmployee(IRegularEmployee employee)
        {
            this.EmployeesList.Remove(this.EmployeesList.First(e => e.Equals(employee)));
        }

        public void RemoveEmployees(IRegularEmployee[] employees)
        {
            foreach (IRegularEmployee employee in employees)
            {
                this.EmployeesList.Remove(this.EmployeesList.First(e => e.Equals(employee)));                
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("Manager: {0} {1} {2} whit employees:\n", this.Id, this.FirstName, this.LastName);
            foreach (var regularEmployee in this.EmployeesList)
            {
                output.AppendLine(regularEmployee.ToString());
            }

            return output.ToString();
        }
    }
}