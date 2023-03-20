
using StudentInformation.Data.Models;

namespace StudentInformation.Bussiness.Abstract
{
    interface IStudentsCourseService
    {
        bool isExistRelation(StudentsCourseModel model);

    }
}
