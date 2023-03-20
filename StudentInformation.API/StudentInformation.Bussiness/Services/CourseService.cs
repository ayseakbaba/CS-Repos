using System.Data.SQLite;
using StudentInformation.Bussiness.Abstract;
using StudentInformation.Data.Models;
using StudentInformation.DataAccess.Concrete;

namespace StudentInformation.Bussiness.Services
{
    public class SQLConnection
    {
        string connectionString = @"Data Source=C:\Users\aysea\Downloads\Programs\SQLiteDatabaseBrowserPortable\App\SQLiteDatabaseBrowser64\studentInformation.db;Version=3;Journal Mode=Off;";
        public SQLiteConnection DBConnection;
        //public SQLConnection()
        //{
        //    CreateSqlConnection();
        //}
        private SQLiteConnection CreateSqlConnection()
        {
            DBConnection = new SQLiteConnection(connectionString);
            DBConnection.Open();
            return DBConnection;
        }

        public void CloseSqlConnection()
        {
            DBConnection.Close();
        }


    }
    public class CourseService : ICourseService
    {
        public CourseModel CreateCourse(CourseModel courseModel)
        {

            if (string.IsNullOrEmpty(courseModel.CourseId) || //Boş veri mi gönderilmeye çalışılıyor
               string.IsNullOrEmpty(courseModel.CourseName))
                return null;

            if (!(isExistCourseId(courseModel.CourseId)))//Kayıt için girilen id numarası tabloda var mı diye kontrol ediyor.
                return null;

            if (!(isExistCourseName(courseModel.CourseName)))
                return null;

            if (!(CheckId(courseModel.CourseId))) //Id formatına uygun mu diye kontrol ediliyor
                return null;

            if (!(CheckName(courseModel.CourseName)))//Geçerli uzunlukta bir kurs adı mı girilmiş.
                return null;
            CourseManagement courseManagement = new CourseManagement();
            CourseModel resultModel = courseManagement.Add(courseModel);
            return resultModel;
        }
        public bool CheckId(string id)
        {
            if (id.Length != 7)
            {
                return false;
            }

            for (int i = 0; i < 3; i++)
            {
                bool result = char.IsDigit(id[i]); //ilk 3 basamak bir dijit mi
                if (!result)
                {
                    if (!(id[i] >= 65 && id[i] <= 90))//büyük harf mi
                    {
                        return false;
                    }
                }
            }
            for (int i = 6; i <= 6 & i>2; i--)//son dört basamak sayı mı?
            {
                bool result = char.IsDigit(id[i]);
                if (!(result))
                {
                    return false;
                }
                    
            }

            return true; ;
        }

        public bool CheckName(string name)
        {
            if (name.Length <1 && name.Length>40)
            {
                return false;
            }
            return true;
        }

        public bool isExistCourseId(string courseId)
        {
            CourseManagement courseManagement = new CourseManagement();
            var result = courseManagement.GetIdForQuery(courseId);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public bool isExistCourseName(string courseName)
        {
            CourseManagement courseManagement1 = new CourseManagement();
            var result = courseManagement1.GetIdForQuery(courseName);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public void isExistTable(string tableName)//Environment değişken olacak
        {//Sorgu sonucu tablo varsa 1 yoksa 0 dönüyor.
            SQLConnection connection = new SQLConnection();
            string sqlQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='" + tableName + "'";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
            int exist = command.ExecuteNonQuery();
            if (exist == 0)
            {
                string createTable = "CREATE TABLE " + tableName + "(" +
                                     tableName + "Id TEXT," +
                                     tableName + "Name TEXT," +
                                     "PRIMARY KEY(" + tableName + "Id);";
                SQLiteCommand createCommand = new SQLiteCommand(createTable, connection.DBConnection);
                createCommand.ExecuteNonQuery();
            }

            connection.DBConnection.Close();
        }
    }
}
