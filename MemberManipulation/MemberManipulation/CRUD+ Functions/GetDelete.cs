using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManipulation.CRUD__Functions
{
    internal class GetDelete
    {
        public static void Delete()
        {
            //Project and Database Connection
            string connectionString = @"Data Source=C:\Users\aysea\Documents\DB Browser for SQLite\memberRegister.db;Version=3;Journal Mode=Off;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            Console.WriteLine("This option is only valid for member table!");

            Console.WriteLine("Member ID : ");
            int id = int.Parse(Console.ReadLine());

            string deleteMem = "Delete from Member where MemberId= " + id;
            string deleteMS = "Delete from Membership where MemberId= " + id;
            SQLiteCommand commandDeleteMem = new SQLiteCommand(deleteMem, connection);
            SQLiteCommand commandDeleteMS = new SQLiteCommand(deleteMS, connection);
            commandDeleteMem.ExecuteNonQuery();
            commandDeleteMS.ExecuteNonQuery();

            Console.WriteLine("Data is successfully deleted from Table");

            connection.Close();
            Console.ReadLine();


        }
    }
}
