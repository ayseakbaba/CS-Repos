using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace MemberManipulation
{
    public class Program
    {
        //A table listing method from the Database
        public static void GetList()
        {
            Console.WriteLine("TABLES\n" +
                "---------------------\n" +
                "\t1.Member\n" +
                "\t2.Category\n");
            Console.Write("Table Number : ");
            string table = Console.ReadLine();

            //Project and Database Connection
            string connectionString = @"Data Source=C:\uyeKaydi.db ";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            switch (table)
            {
                case "1":
                    //Geting data from Member table
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


        //A method that finds the member with the help of the member ID and lists its information
        public static void Find()
        {
            Console.Write("Member ID: ");
            string id = Console.ReadLine();

            //Project and Database Connection
            string connectionString = @"Data Source=C:\uyeKaydi.db ";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            //Create result table acording to MemberId
            string sqlMember = "SELECT Member.MemberId, Member.FirstName,Member.LastName,Member.BDate,Member.Email,Category.CategoryId,Category.CategoryName" +
                               " From Member,Category, Membership" +
                               " where Member.MemberId = Membership.MemberId and Category.CategoryId = Membership.CategoryId and Membership.MemberId = " + id;
            SQLiteCommand commandMem = new SQLiteCommand(sqlMember, connection);
            var readerMem = commandMem.ExecuteReader();
            while (readerMem.Read())
            {
                Console.WriteLine($"{readerMem.GetInt32(0)} | {readerMem.GetString(1)} | {readerMem.GetString(2)} | " +
                                  $"{readerMem.GetString(3)} | {readerMem.GetString(4)} | {readerMem.GetString(5)} | " +
                                  $"{readerMem.GetString(6)}");
            }
            connection.Close();
            Console.ReadLine();

        }


        static void Main(string[] args)
        {
            Console.WriteLine("------ MEMBER ENQUIRY ------");
            Console.WriteLine("------OPTIONS------\n" +
                "\t1.List a table from database\n" +
                "\t2.Member information enquiry with member id");
            Console.Write("Choosed Option Number: ");
            string choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    GetList();
                    break;
                case "2":
                    Find(); 
                    break;
                default:
                    Console.WriteLine("Invalid Option Number!");
                    break;
            }

        }
    }

}

    
