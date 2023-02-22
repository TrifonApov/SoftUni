namespace CompanyHierarchy.Interfaces
{
    using Enums;

    public interface IEmployee
    {
        decimal Salary { get; set; }
        Department Department { get; set; } 
    }
}