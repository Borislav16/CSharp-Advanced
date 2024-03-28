using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {

        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;
        private List<string> categories = new List<string> { "TechnicalSubject", "EconomicalSubject", "HumanitySubject" };

        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }


        public string AddSubject(string subjectName, string subjectType)
        {
            if(!categories.Contains(subjectType)) 
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            
            }

            if(subjects.FindByName(subjectName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            Subject subject = null;
            if(subjectType == "TechnicalSubject")
            {
                subject = new TechnicalSubject(0, subjectName);
            }
            if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(0, subjectName);
            }
            if (subjectType == "HumanitySubject")
            {
                subject = new HumanitySubject(0, subjectName);
            }

            subjects.AddModel(subject);

            return String.Format(OutputMessages.SubjectAddedSuccessfully,subject.GetType().Name, subjectName, subjects.GetType().Name);
        }

        public string AddStudent(string firstName, string lastName)
        {
            string fullName = firstName + " " + lastName;
            if(students.FindByName(fullName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            Student student = new Student(0, firstName, lastName);
            students.AddModel(student);

            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, students.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if(universities.FindByName(universityName) != null) 
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            List<int> requiredSubjectsAsInts = requiredSubjects.Select(s => subjects.FindByName(s).Id).ToList();
            University university = new University(0, universityName, category, capacity, requiredSubjectsAsInts);
            universities.AddModel(university);
            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universities.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] splitted = studentName.Split(' ');
            IStudent student = students.FindByName(studentName);
            if(student == null) 
            {
                return String.Format(OutputMessages.StudentNotRegitered, splitted[0], splitted[1]);
            }
            IUniversity university = universities.FindByName(universityName);
            if (university == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            foreach (var item in university.RequiredSubjects)
            {
                if(!student.CoveredExams.Contains(item))
                {
                    return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            if(student.University != null && student.University.Name == university.Name)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, student.FirstName, student.LastName, university.Name);
            }
            student.JoinUniversity(university);
            return String.Format(OutputMessages.StudentSuccessfullyJoined, student.FirstName, student.LastName, university.Name);

        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            if(student == null)
            {
                return OutputMessages.InvalidStudentId;
            }
            ISubject subject = subjects.FindById(subjectId);
            if (subject == null)
            {
                return OutputMessages.InvalidSubjectId;
            }
            if(student.CoveredExams.Contains(subjectId))
            {
                return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }

            student.CoverExam(subject);
            return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);

        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);
            StringBuilder stringBuilder = new StringBuilder();
            int admittedStudents = CountStudentsInUni(university);
            stringBuilder.AppendLine($"*** {university.Name} ***");
            stringBuilder.AppendLine($"Profile: {university.Category}");
            stringBuilder.AppendLine($"Students admitted: {admittedStudents}");
            stringBuilder.AppendLine($"University vacancy: {university.Capacity - admittedStudents}");

            return stringBuilder.ToString().Trim();
        }

        private int CountStudentsInUni(IUniversity university)
        {
            int count = 0;
            foreach(var student in students.Models)
            {
                if(student.University?.Id == university.Id)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
