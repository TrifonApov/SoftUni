namespace CompanyHierarchy.Models.Employees
{
    using Enums;
    using Interfaces;

    public abstract class RegularEmployee : Employee, IRegularEmployee
    {
        protected RegularEmployee(int id, string firstName, string lastName, decimal salary, Department department) 
            : base(id, firstName, lastName, salary, department)
        {
        }
    }
}