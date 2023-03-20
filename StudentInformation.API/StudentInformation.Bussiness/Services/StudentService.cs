using StudentInformation.Bussiness.Abstract;
using StudentInformation.DataAccess.Concrete;
using StudentInformation.Data.Models;

namespace StudentInformation.Bussiness.Services
{
    public class StudentService : IStudentService
    {
        public StudentModel CreateStudent(StudentModel student)
        {
            if (!(isExistStudentNumber(student.StudentNumber)))
                return null;

            if (!(CheckStudentNumber(student.StudentNumber)))
                return null;

            if (!(CheckFirstName(student.FirstName)))
                return null;

            if (!(CheckLastName(student.LastName)))
                return null;

            StudentManager studentManager = new StudentManager();
            StudentModel resultModel = studentManager.Add(student);
            return resultModel;

        }
        public bool CheckFirstName(string firstName)
        {
            if(string.IsNullOrEmpty(firstName))
            {
                return false;
            }
            if (firstName.Length <= 1) 
            {
                return false;
            }
            return true;
        }

        public bool CheckLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if(lastName.Length < 1)
            {
                return false;
            }
            return true;
        }

        public bool CheckStudentNumber(int studentNumber)
        {
            if(studentNumber > 2020123000 && studentNumber < 2020123101)
            {
                return true;
            }
            return false;
        }

        public bool isExistStudentNumber(int studentNumber)
        {
            StudentManager studentManager = new StudentManager();
            var result = studentManager.Get(studentNumber);
            if (result.FirstName == null)
            {
                return true;
            }
            return false;
        }
    }
}
