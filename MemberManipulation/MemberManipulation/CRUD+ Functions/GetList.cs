using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManipulation.CRUD__Functions
{
    public class GetList
    {
        public static void List()
        {
            Console.WriteLine("TABLES\n" +
                "---------------------\n" +
                "\t1.Member\n" +
                "\t2.Category\n");
            Console.Write("Table Number : ");
            string table = Console.ReadLine();

            //Project and Database Connection
            string connectionString = @"Data Source=C:\Users\aysea\Documents\DB Browser for SQLite\memberRegister.db ";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            switch (table)
            {
                case "1":
                    //Geting data from Member table
                    table = "Member";
                    string sqlMember = "select MemberId, FirstName, LastName from " + table;
                    SQLiteCommand commandMem = new SQLiteCommand(sqlMember, connection);
                    var readerMem = commandMem.ExecuteReader();
                    while (readerMem.Read())
                    {
                        Console.WriteLine($"{readerMem.GetInt32(0)} {readerMem.GetString(1)} {readerMem.GetString(2)}");
                    }
                    break;
                case "2":
                    //Geting data from Category table
                    table = "Category";
                    string sqlCategory = "select CategoryId, CategoryName from " + table;
                    SQLiteCommand commandCat = new SQLiteCommand(sqlCategory, connection);
                    var readerCat = commandCat.ExecuteReader();
                    while (readerCat.Read())
                    {
                        Console.WriteLine($"{readerCat.GetString(0)} {readerCat.GetString(1)}");
                    }
                    break;
                default:
                    Console.WriteLine("Error: Invalid Table Name!");
                    break;
            }

            connection.Close();


            Console.ReadLine();
        }
    }
}
