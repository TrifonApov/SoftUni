namespace CompanyHierarchy.Models.Employees
{
    using System.Collections.Generic;

    public class Manager : Employee
    {
        private ICollection<RegularEmployee> regularEmployees;

        public Manager()
        {
            this.RegularEmployees = new HashSet<RegularEmployee>();
        }

        public ICollection<RegularEmployee> RegularEmployees
        {
            get { return this.regularEmployees; }
            set { this.regularEmployees = value; }
        }
    }
}