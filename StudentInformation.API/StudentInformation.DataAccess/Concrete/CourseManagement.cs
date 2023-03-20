using StudentInformation.DataAccess.Abstract;
using StudentInformation.Data.Models;
using System.Data.SQLite;

namespace StudentInformation.DataAccess.Concrete
{
    public class SQLConnection
    {
        string connectionString = @"Data Source=C:\Users\aysea\Downloads\Programs\SQLiteDatabaseBrowserPortable\App\SQLiteDatabaseBrowser64\studentInformation.db;Version=3;Journal Mode=Off;";
        public SQLiteConnection DBConnection;
        public SQLConnection()
        {
            CreateSqlConnection();
        }
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
    public class CourseManagement : IRepository<CourseModel>
    {
        public CourseModel Add(CourseModel entity)
        {//Nesne dönüyor

            SQLConnection connection = new SQLConnection();
            CourseModel model = new CourseModel();

            string sqlQuery = "INSERT INTO Course(CourseId, CourseName) VALUES" +
                                         "('" + entity.CourseId + "','" + entity.CourseName + "')";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
            command.ExecuteNonQuery();

            model.CourseId = entity.CourseId;
            model.CourseName = entity.CourseName;

            connection.CloseSqlConnection();
            return model;
        }

        public string Delete(string id)
        {//Bilgi dönüyor
            SQLConnection connection = new SQLConnection();

            string sqlQuery = $"Delete from Course where CourseId= '{id}'";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
            command.ExecuteNonQuery();

            connection.CloseSqlConnection();
            return id + " deleted";
        }

        public string Delete(int id)
        {//Bilgi dönüyor
            // Ortak interfacede iki farklı parametre alınması gerektiği için kullanacağımı kodluyorum diğeri bu şekilde boşta duruyor
            throw new NotImplementedException();
        }

        public CourseModel GetIdForQuery(string id)//Bu fonksiyon kurs adı ve id kontrollerinde ortak kullanılır.
        {//Nesne dönüyor
            CourseModel _model = new CourseModel();
            SQLConnection connection = new SQLConnection();
            bool result = char.IsDigit(id[3]);
            if (result)//id için sorgu
            {
                string sqlQuery = "SELECT * FROM Course WHERE CourseId = '" + id + "'";

                SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
                var reader = command.ExecuteScalar();
                if (reader == null)
                {
                    command.Parameters.Add(new SQLiteParameter("CourseId", id));
                    return _model;
                }

                if (reader.Equals(id))
                {
                    return null;
                }
            }
            else //Course adı için sorgu
            {
                string sqlQuery = "SELECT CourseName,CourseId FROM Course WHERE CourseName = '" + id + "'";
                SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
                var reader = command.ExecuteScalar();
                if (reader == null)
                {
                    command.Parameters.Add(new SQLiteParameter("CourseName", id));
                    return _model;
                }

                if (reader.Equals(id))
                {
                    return null;
                }
            }
            connection.CloseSqlConnection();

            return _model;


        }

        public CourseModel Get(int id)
        {
            // Ortak interfacede iki farklı parametre alınması gerektiği için kullanacağımı kodluyorum diğeri bu şekilde boşta duruyor
            throw new NotImplementedException();
        }

        public List<CourseModel> GetAll()
        {
            SQLConnection connection = new SQLConnection();
            List<CourseModel> _list = new List<CourseModel>();
            string sqlQuery = "SELECT * FROM Course";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                _list.Add(new CourseModel
                {
                    CourseId = reader.GetString(0),
                    CourseName = reader.GetString(1)
                });
            }
            connection.CloseSqlConnection();
            return _list;

        }

        public CourseModel Update(CourseModel entity)
        {//Nesne dönüyor
            SQLConnection connection = new SQLConnection();
            CourseModel model = new CourseModel();
            string sqlQuery = "UPDATE Course SET CourseName = '" + entity.CourseName + "' WHERE CourseID = '" + entity.CourseId + "'";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
            command.ExecuteNonQuery();
            model.CourseId = entity.CourseId;
            model.CourseName = entity.CourseName;
            connection.CloseSqlConnection();
            return model;
        }

        public CourseModel Get(string id)
        {
            SQLConnection connection = new SQLConnection();
            CourseModel model = new CourseModel();
            string sqlQuery = $"SELECT * FROM Course WHERE CourseId= '{id}'";
            SQLiteCommand command = new SQLiteCommand( sqlQuery, connection.DBConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                model.CourseId = reader.GetString(0);
                model.CourseName = reader.GetString(1);


            }
            connection.CloseSqlConnection();
            return model;
        }
    }
}
