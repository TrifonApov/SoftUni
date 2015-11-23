namespace SoftUniLearningSystem.Students.CurrentStudents
{
    using System;
    using System.Text;

    public class OnsiteStudent : CurrentStudent
    {
        private int visits;

        public OnsiteStudent(string firstName, string lastName, int age, string currentCourse, int visits, double avgGrade, string number) 
            : base(firstName, lastName, age, currentCourse, avgGrade, number)
        {
            this.Visits = visits;
        }

        public int Visits
        {
            get { return this.visits; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Visits should be positive.");
                }
                this.visits = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Onsite Student - {0} {1}\n", this.FirstName, this.LastName);
            output.AppendFormat("{1}{0:f2}\n", this.AverageGrade, "-->Average Grade".PadRight(20, '.'));
            output.AppendFormat("{1}{0}\n", this.Number, "-->Number".PadRight(20, '.'));
            output.AppendFormat("{1}{0}\n", this.Age, "-->Age".PadRight(20, '.'));
            output.AppendFormat("{1}{0}\n", this.CurrentCourse, "-->Current Course".PadRight(20, '.'));
            output.AppendFormat("{1}{0}\n", this.Visits, "-->Visits".PadRight(20, '.'));
            return output.ToString();
        }
    }
}