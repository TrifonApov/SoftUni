namespace CompanyHierarchy.Models.Employees
{
    using System;
    using Enums;

    public abstract class Employee : Person
    {
        private decimal salary;
        private Department department;

        public decimal Salary
        {
            get { return this.salary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(
                        nameof(value),
                        "Salary cannot be negative.");
                }
                this.salary = value;
            }
        }

        public Department Department
        {
            get { return this.department; }
            set { this.department = value; }
        }
    }
}