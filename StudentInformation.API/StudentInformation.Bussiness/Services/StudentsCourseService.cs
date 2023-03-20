
using StudentInformation.Bussiness.Abstract;
using StudentInformation.Data.Models;
using StudentInformation.DataAccess.Concrete;

namespace StudentInformation.Bussiness.Services
{
    public class StudentsCourseService : IStudentsCourseService
    {
        StudentsCourseManagement SCManagement;
        StudentService StudentService = new StudentService();
        CourseService CourseService= new CourseService();

        public StudentsCourseModel CreateStudentsCourse(StudentsCourseModel studentsCourse)
        {
            if(string.IsNullOrEmpty(studentsCourse.CourseId )||
                studentsCourse.StudentNumber == 0)
                return null;

            if (!(isExistRelation(studentsCourse)))
                return null;

            if (!(StudentService.CheckStudentNumber(studentsCourse.StudentNumber)))
                return null;

            if (!(CourseService.CheckId(studentsCourse.CourseId)))
                return null;

            SCManagement = new StudentsCourseManagement();
            StudentsCourseModel model = SCManagement.Add(studentsCourse);
            return model;

        }
        public bool isExistRelation(StudentsCourseModel model)
        {
            SCManagement = new StudentsCourseManagement();
            var result = SCManagement.GetModelForQuery(model);
            if(result == null) 
                return false;
            return true;

            

        }
    }
}
