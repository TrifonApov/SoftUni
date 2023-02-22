namespace SoftUniLearningSystem.Students.CurrentStudents
{
    using System.Text;

    public class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int age, string currentCourse, double avgGrade, string number) : base(firstName, lastName, age, currentCourse, avgGrade, number)
        {
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Online Student - {0} {1}\n", this.FirstName, this.LastName);
            output.AppendFormat("{1}{0:f2}\n", this.AverageGrade, "-->Average Grade".PadRight(20,'.'));
            output.AppendFormat("{1}{0}\n", this.Number, "-->Number".PadRight(20, '.'));
            output.AppendFormat("{1}{0}\n", this.Age, "-->Age".PadRight(20, '.'));
            output.AppendFormat("{1}{0}\n", this.CurrentCourse, "-->Current Course".PadRight(20, '.'));
            
            return output.ToString();
        }
    }
}