namespace CompanyHierarchy.Models.Employees
{
    using System;
    using System.Text;
    using Enums;
    using Interfaces;

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        protected Employee(int id, string firstName, string lastName, decimal salary, Department department)
            : base (id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                Validation.Validate.IsNegative("Employee's salary", value);
                this.salary = value;
            }
        }

        public Department Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString());
            output.Append(string.Format(" - Salary: {0:C2}, Department: {1}\n",
                this.Salary,
                this.Department));

            return output.ToString();
        }
    }
}