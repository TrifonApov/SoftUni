namespace SoftUniLearningSystem.Students.CurrentStudents
{
    using System;
    using System.Text;

    public class CurrentStudent : Student
    {
        private string currentCourse;

        public CurrentStudent(string firstName, string lastName, int age, string currentCourse, double avgGrade, string number) 
            : base(firstName, lastName, age, avgGrade, number)
        {
            this.CurrentCourse = currentCourse;
        }

        public string CurrentCourse
        {
            get { return this.currentCourse; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Course`s name should be at least 3 symbols.");
                }
                this.currentCourse = value;
            }
        }
    }
}