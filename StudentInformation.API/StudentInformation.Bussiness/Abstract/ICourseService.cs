using StudentInformation.Data.Models;

namespace StudentInformation.Bussiness.Abstract
{
    interface ICourseService
    {
        bool isExistCourseId(string courseId); //Daha önceden kullanılmış bir course id mi 
        bool isExistCourseName(string courseName);//Daha önceden kullanılmış bir course adı mı
        bool CheckId(string courseId);//Kurs id kuralları (7 haneli olacak ilk üçü büyük harf son dördü rakam olmalı)
        bool CheckName(string courseName);//ismi birden küçük 40'tan büyük olamaz. isim özel karakter ile başlayamaz
        void isExistTable(string tableName);
    }
}
