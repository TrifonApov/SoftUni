namespace SoftUniLearningSystem.Students
{
    using System.Text;

    public class GraduateStudent : Student
    {
        public GraduateStudent(string firstName, string lastName, int age, double avgGrade, string number) 
            : base(firstName, lastName, age, avgGrade, number)
        {
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Congratulations {0} {1}! ({2})\n", this.FirstName, this.LastName, this.Number);
            output.AppendFormat("At age of {0} you successfully graduated SoftUni.\n", this.Age);
            output.AppendFormat("Average grade: {0}", this.AverageGrade);
            return output.ToString();
        }
    }
}