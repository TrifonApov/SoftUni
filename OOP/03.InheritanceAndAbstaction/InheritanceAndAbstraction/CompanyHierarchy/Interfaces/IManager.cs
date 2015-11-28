namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface IManager
    {
        ICollection<IRegularEmployee> EmployeesList { get; set; }
        void AddEmployee(IRegularEmployee employee);
        void AddEmployees(IRegularEmployee[] employees);
        void RemoveEmployee(IRegularEmployee employee);
        void RemoveEmployees(IRegularEmployee[] employees);
    }
}