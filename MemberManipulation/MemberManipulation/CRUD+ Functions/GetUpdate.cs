using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManipulation.CRUD__Functions
{
    internal class GetUpdate
    {
        public static void Update()
        {
            //Project and Database Connection
            string connectionString = @"Data Source=C:\Users\aysea\Documents\DB Browser for SQLite\memberRegister.db;Version=3;Journal Mode=Off;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            Console.WriteLine("This option is only valid for member table!");

            Console.Write("Member ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Columns Are: FirstName, LastName, Bdate and Email");
            Console.Write("Chosed Column Name: ");
            string column = Console.ReadLine();

            Console.WriteLine("New Value");
            string newValue = Console.ReadLine();

            string updateMem = "update Member set " + column + " = '" + newValue + "' where MemberId = " + id;
            SQLiteCommand commandUpdateMem = new SQLiteCommand(updateMem, connection);
            commandUpdateMem.ExecuteNonQuery();
            Console.WriteLine("Data is successfully updated in Table");

            connection.Close();
            Console.ReadLine();
        }
    }
}
