namespace CompanyHierarchy.Models.Employees
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enums;
    using Interfaces;
    using Sales;

    public class Developer :RegularEmployee, IDeveloper
    {
        private ICollection<Project> setOfProject;

        public Developer(int id, string firstName, string lastName, decimal salary, Department department) 
            : base(id, firstName, lastName, salary, department)
        {
            this.SetOfProject = new List<Project>();
        }

        public ICollection<Project> SetOfProject
        {
            get { return this.setOfProject; }
            set { this.setOfProject = value; }
        }

        public void AddProject(Project project)
        {
            this.SetOfProject.Add(project);
        }

        public void AddProjects(Project[] projects)
        {
            foreach (Project project in projects)
            {
                this.SetOfProject.Add(project);
            }
        }

        public void RemoveProject(Project project)
        {
            this.SetOfProject.Remove(this.SetOfProject.First(p => p.Equals(project)));
        }

        public void RemoveProjects(Project[] projects)
        {
            foreach (Project project in projects)
            {
                this.SetOfProject.Remove(this.SetOfProject.First(p => p.Equals(project)));
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine("---Projects:");
            foreach (var project in this.SetOfProject)
            {
                output.AppendLine("-----" + project);
            }
            return output.ToString();
        }
    }
}