namespace CompanyHierarchy.Models.Sales
{
    using System;
    using Enums;

    public class Project
    {
        private string projectName;
        private DateTime startDate;
        private ProjectState projectState;

        public Project(string projectName, DateTime startDate)
        {
            this.ProjectName = projectName;
            this.StartDate = startDate;
        }

        public string ProjectName
        {
            get { return this.projectName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        nameof(value),
                        "Project name cannot be null or empty.");
                }
                this.projectName = value;
            }
        }

        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        public string Details { get; set; }

        public ProjectState ProjectState
        {
            get { return this.projectState; }
            private set {
                this.projectState = this.StartDate <= DateTime.Now
                    ? ProjectState.Open
                    : ProjectState.Close;
            }
        }

        public void CloseProject()
        {
            this.ProjectState = ProjectState.Close;
        }
    }
}