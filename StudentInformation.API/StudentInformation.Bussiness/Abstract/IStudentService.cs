
namespace StudentInformation.Bussiness.Abstract
{
    interface IStudentService
    {
        bool isExistStudentNumber(int studentNumber);
        bool CheckFirstName(string firstName);
        bool CheckLastName(string lastName);
        bool CheckStudentNumber(int studentNumber);
    }
}
