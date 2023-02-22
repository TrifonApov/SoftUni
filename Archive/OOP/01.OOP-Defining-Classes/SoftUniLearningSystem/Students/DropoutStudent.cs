namespace SoftUniLearningSystem.Students
{
    using System;
    using System.Text;

    public class DropoutStudent : Student
    {
        private string reason;

        public DropoutStudent(string firstName, string lastName, int age, string reason, double avgGrade, string number) 
            : base(firstName, lastName, age, avgGrade, number)
        {
            this.Reason = reason;
        }

        public string Reason
        {
            get { return this.reason; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Reason shoud be at least 5 symbol.");
                }
                this.reason = value;
            }
        }

        public void Reapply()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("{0} {1} ({2} years old) wants to reapply.\n",this.FirstName,this.LastName,this.Age);
            output.AppendFormat("Reason to dropout: {0}\n", this.Reason);
            output.AppendFormat("Student number is {0}. Average grade is {1}", this.Number, this.AverageGrade);
            return output.ToString();
        }
    }
}