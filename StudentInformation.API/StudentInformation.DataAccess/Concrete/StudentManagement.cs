
using StudentInformation.Data.Models;
using StudentInformation.DataAccess.Abstract;
using System.Data.SQLite;

namespace StudentInformation.DataAccess.Concrete
{
    public class StudentManager : IRepository<StudentModel>
    {
        public StudentModel Add(StudentModel entity)
        {
            //Nesne dönüyor

            SQLConnection connection = new SQLConnection();
            StudentModel model = new StudentModel();

            string sqlQuery = $"INSERT INTO Student(StudentNumber, FirstName, LastName) VALUES({entity.StudentNumber}, '{entity.FirstName}', '{entity.LastName}')";


            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
            command.ExecuteNonQuery();

            model.StudentNumber = entity.StudentNumber;
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;

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
            //Bilgi dönüyor
            SQLConnection connection = new SQLConnection();

            string sqlQuery = $"Delete from Student where StudentNumber= {id}";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection.DBConnection);
            command.ExecuteNonQuery();

            connection.CloseSqlConnection();
            return id + " deleted";
        }
    

        public StudentModel Get(string id)
        {
            // Ortak interfacede iki farklı parametre alınması gerektiği için kullanacağımı kodluyorum diğeri bu şekilde boşta duruyor
            throw new NotImplementedException();
        }

        public StudentModel Get(int id)
        {
            SQLConnection connection = new SQLConnection();
            StudentModel model = new StudentModel();

            string sqlQuery = $"SELECT * FROM Student WHERE StudentNumber= {id}";
            SQLiteCommand command = new SQLiteCommand(sqlQuery,connection.DBConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                model.StudentNumber = reader.GetInt32(0);
                model.FirstName = reader.GetString(1);
                model.LastName = reader.GetString(2);
            }

            connection.CloseSqlConnection();
            return model;

        }

        public List<StudentModel> GetAll()
        {
            SQLConnection connection = new SQLConnection();
            List<StudentModel> _list = new List<StudentModel>();
            string sqlQuery = "Select * From Student";
            SQLiteCommand command = new SQLiteCommand( sqlQuery,connection.DBConnection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                _list.Add(new StudentModel
                {
                    StudentNumber = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                });
            }
            connection.CloseSqlConnection();
            return _list;
        }

        public StudentModel Update(StudentModel entity)
        {
            SQLConnection connection = new SQLConnection();
            StudentModel model = new StudentModel();
            string sqlQuery = $"Update Student SET FirstName = '{entity.FirstName}', LastName = '{entity.LastName}' Where StudentNumber = {entity.StudentNumber}";
            SQLiteCommand command = new SQLiteCommand (sqlQuery,connection.DBConnection);
            command.ExecuteNonQuery();
            model.StudentNumber = entity.StudentNumber;
            model.FirstName = entity.FirstName;
            model.LastName = entity.LastName;
            return model;
        }
    }
}
