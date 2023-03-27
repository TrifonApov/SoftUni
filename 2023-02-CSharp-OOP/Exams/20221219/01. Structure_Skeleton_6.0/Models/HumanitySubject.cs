namespace UniversityCompetition.Models
{
    public class HumanitySubject : Subject
    {
        private const double SubjectRate = 1.15;

        public HumanitySubject(int id, string name) 
            : base(id, name, SubjectRate)
        {
        }
    }
}