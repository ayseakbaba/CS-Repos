using StudentInformation.Data.Models;
using StudentInformation.DataAccess.Abstract;
using System.Data.SQLite;

namespace StudentInformation.DataAccess.Concrete
{
    public class StudentsCourseManagement : IRepository<StudentsCourseModel>
    {
        public StudentsCourseModel Add(StudentsCourseModel entity)
        {
            SQLConnection connection = new SQLConnection();
            StudentsCourseModel model = new StudentsCourseModel();

            string sqlQuery = $"Insert Into StudentsCourse(StudentNumber, CourseId) Values({entity.StudentNumber},'{entity.CourseId}')";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
            command.ExecuteNonQuery();

            model.StudentNumber = entity.StudentNumber;
            model.CourseId = entity.CourseId;   

            connection.CloseSqlConnection();
            return model;
        }

        public string Delete(string id)
        {
            // Ortak interfacede iki farklı parametre alınması gerektiği için kullanacağımı kodluyorum diğeri bu şekilde boşta duruyor
            throw new NotImplementedException();
        }

        public string Delete(int id)
        {
            SQLConnection connection = new SQLConnection();

            string sqlQuery = $"Delete from StudentsCourse where StudentNumber = {id}";
            SQLiteCommand command = new SQLiteCommand(sqlQuery , connection.DBConnection);
            command.ExecuteNonQuery();  

            connection.CloseSqlConnection();
            return id + "deleted";
        }

        public StudentsCourseModel Get(string courseId)
        {
            SQLConnection connection = new SQLConnection();
            StudentsCourseModel model = new StudentsCourseModel() ;

            string sqlQuery = $"Select * From StudentsCourse Where CourseId= '{courseId}'";
            SQLiteCommand command = new SQLiteCommand (sqlQuery , connection.DBConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                model.StudentNumber = reader.GetInt32(0);
                model.CourseId = reader.GetString(1);
            }
            connection.CloseSqlConnection();
            return model;
           
        }

        public StudentsCourseModel GetModelForQuery(StudentsCourseModel entity)
        {
            SQLConnection connection = new SQLConnection();

            string sqlQuery = $"Select * From StudentsCourse Where StudentNumber= {entity.StudentNumber}";
            SQLiteCommand command = new SQLiteCommand (sqlQuery , connection.DBConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetInt32(0) == entity.StudentNumber && reader.GetString(1) == entity.CourseId)
                    return null;
            }
            connection.CloseSqlConnection();
            return entity;
        }

        public List<StudentsCourseModel> GetAll()
        {
            SQLConnection connection = new SQLConnection();
            List< StudentsCourseModel> list = new List<StudentsCourseModel> ();
            
            string sqlQuery = $"Select * From StudentsCourse";
            SQLiteCommand command = new SQLiteCommand ( sqlQuery , connection.DBConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new StudentsCourseModel
                {
                    StudentNumber = reader.GetInt32(0),
                    CourseId = reader.GetString(1)
                });
            }
            connection.CloseSqlConnection();
            return list;
        }


        //public StudentsCourseModel Update(StudentsCourseModel entity)
        //{
        //    SQLConnection connection = new SQLConnection ();
        //    StudentsCourseModel model = new StudentsCourseModel ();

        //    string sqlQuery = $"Update StudentsCourse Set CourseId = '{entity.CourseId}'";
        //    SQLiteCommand command = new SQLiteCommand (sqlQuery , connection.DBConnection);
        //    command.ExecuteNonQuery ();
        //    model.StudentNumber = entity.StudentNumber;
        //    model.CourseId = entity.CourseId;
        //    return model;
        //}

        public StudentsCourseModel Get(int id)
        {
            SQLConnection connection = new SQLConnection();
            StudentsCourseModel model = new StudentsCourseModel();

            string sqlQuery = $"Select * From StudentsCourse Where StudentNumber= {id}";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                model.StudentNumber = reader.GetInt32(0);
                model.CourseId = reader.GetString(1);
            }
            connection.CloseSqlConnection();
            return model;
        }

        public StudentsCourseModel Update(StudentsCourseModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
