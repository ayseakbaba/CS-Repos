
namespace StudentInformation.Data.Models
{
    public class CourseModel
    {
        public string CourseId { get; set; }// 1. adım : ıd doğruluğu
        public string CourseName { get; set; } // 2. adım : isim boş ve ya null && uzunluk kontrolleri
    }
}
