namespace UniversityCompetition.Models
{
    public class EconomicalSubject : Subject
    {
        private const double SubjectRate = 1.0;

        public EconomicalSubject(int id, string name) 
            : base(id, name, SubjectRate)
        {
        }
    }
}