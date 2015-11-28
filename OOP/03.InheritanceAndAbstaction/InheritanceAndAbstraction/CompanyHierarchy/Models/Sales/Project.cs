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
            this.ProjectState = ProjectState.Open;
        }

        public string ProjectName
        {
            get { return this.projectName; }
            set
            {
                Validation.Validate.IsNullOrEmpty("Prject name", value);
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
            private set { this.projectState = value; }
        }

        public void CloseProject()
        {
            this.ProjectState = ProjectState.Close;
        }
        
        public override string ToString()
        {
            return string.Format("Project name: {0}, Details: {1}, Start: {2:dd-MM-yyyy} State: {3}",
                this.ProjectName,
                string.IsNullOrWhiteSpace(this.Details) ? "No details" : this.Details,
                this.StartDate,
                this.ProjectState);
        }
    }
}