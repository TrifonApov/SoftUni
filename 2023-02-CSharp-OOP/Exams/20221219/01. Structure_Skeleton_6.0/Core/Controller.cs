using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjectRepository;
        private StudentRepository studentRepository;
        private UniversityRepository universityRepository;

        private int generatedSubjectId;
        private int generatedStudentId;
        private int generatedUniversityId;

        public Controller()
        {
            this.subjectRepository = new SubjectRepository();
            this.studentRepository = new StudentRepository();
            this.universityRepository = new UniversityRepository();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectRepository.FindByName(subjectName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            switch (subjectType)
            {
                case "HumanitySubject":
                    subjectRepository.AddModel(new HumanitySubject(++generatedSubjectId, subjectName));
                    break;
                case "EconomicalSubject":
                    subjectRepository.AddModel(new EconomicalSubject(++generatedSubjectId, subjectName));
                    break;
                case "TechnicalSubject":
                    subjectRepository.AddModel(new TechnicalSubject(++generatedSubjectId, subjectName));
                    break;
                default:
                    return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }

            return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, "SubjectRepository");
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universityRepository.FindByName(universityName) != null)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            ICollection<int> requiredSubjectsIds = new List<int>();
            foreach (string subjectName in requiredSubjects)
            {
                requiredSubjectsIds.Add(subjectRepository.FindByName(subjectName).Id);
            }

            IUniversity university = new University(++generatedUniversityId, universityName, category, capacity, requiredSubjectsIds);
            universityRepository.AddModel(university);

            return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, "UniversityRepository");
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (studentRepository.FindByName($"{firstName} {lastName}") != null)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }

            IStudent student = new Student(++generatedStudentId, firstName, lastName);
            studentRepository.AddModel(student);

            return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, "StudentRepository");
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (studentRepository.FindById(studentId) == null)
            {
                return OutputMessages.InvalidStudentId;
            }

            if (subjectRepository.FindById(subjectId) == null)
            {
                return OutputMessages.InvalidSubjectId;
            }

            IStudent student = studentRepository.FindById(studentId);
            ISubject subject = subjectRepository.FindById(subjectId);

            if (student.CoveredExams.Contains(subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);

            return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] splittedName = studentName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = splittedName[0];
            string lastName = splittedName[1];

            IStudent student = studentRepository.FindByName(studentName);
            IUniversity university = universityRepository.FindByName(universityName);

            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }


            if (university.RequiredSubjects.Any(requiredSubject => !student.CoveredExams.Contains(requiredSubject)))
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }

            if (student.University != null && student.University.Name == universityName)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, university.Name);
            }

            student.JoinUniversity(university);

            return string.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, university.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universityRepository.FindById(universityId);

            int studentsInUniversity = (studentRepository.Models.Where(s=>s.University != null).Where(s => s.University.Id == universityId)).Count();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsInUniversity}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsInUniversity}");

            return sb.ToString().Trim();
        }
    }
}