namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;
    using Models.Sales;

    public interface IDeveloper
    {
        ICollection<Project> SetOfProject { get; set; }
        void AddProject(Project project);
        void AddProjects(Project[] projects);
        void RemoveProject(Project project);
        void RemoveProjects(Project[] projects);
    }
}