using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManipulation.CRUD__Functions
{
    internal class GetInsert
    {
        public static void Insert()
        {
            //Project and Database Connection
            string connectionString = @"Data Source=C:\Users\aysea\Documents\DB Browser for SQLite\memberRegister.db;Version=3;Journal Mode=Off;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            Console.WriteLine("Which to table do you want to add?\n" + "\t1.Member\n" + "\t2.Category\n" + "\t3.Membership\n");
            Console.Write("Table Number : ");
            string table = Console.ReadLine();

            //Getting parameters
            switch (table)
            {
                case "1":
                    Console.Write("the person you want to add: \n" +
                                  "\tFirst Name : ");
                    string name = Console.ReadLine();
                    Console.Write("\tLast Name : ");
                    string lname = Console.ReadLine();
                    Console.Write("\tBirthdate : ");
                    string bDate = Console.ReadLine();
                    Console.Write("\tEmail : ");
                    string email = Console.ReadLine();


                    string insertMem = "INSERT INTO Member(FirstName, LastName, BDate, Email) VALUES" +
                                         "('" + name + "','" + lname + "','" + bDate
                                         + "','" + email + "')";
                    SQLiteCommand commandInsMem = new SQLiteCommand(insertMem, connection);
                    commandInsMem.ExecuteNonQuery();
                    Console.WriteLine("Data is successfully inserted into Table");
                    break;

                case "2":
                    Console.Write("the category you want to add: \n");
                    Console.Write("\tCategoryId (like SAN05) : ");
                    string catID = Console.ReadLine();
                    Console.Write("\tCategoryName : ");
                    string catName = Console.ReadLine();

                    string insertCat = "INSERT INTO Category(CategoryId, CategoryName) VALUES" +
                                         "('" + catID + "','" + catName + "')";
                    SQLiteCommand commandInsCat = new SQLiteCommand(insertCat, connection);
                    commandInsCat.ExecuteNonQuery();
                    Console.WriteLine("Data is successfully inserted into Table");
                    break;

                case "3":
                    Console.Write("the membership you want to add: \n");
                    Console.Write("\tMember ID : ");
                    int msMemID = int.Parse(Console.ReadLine());
                    Console.Write("\tCategoryId (like SAN05) : ");
                    string msCatID = Console.ReadLine();

                    string insertMS = "INSERT INTO Membership(MemberId, CategoryId) VALUES" +
                                         "('" + msMemID + "','" + msCatID + "')";
                    SQLiteCommand commandInsMS = new SQLiteCommand(insertMS, connection);
                    commandInsMS.ExecuteNonQuery();
                    Console.WriteLine("Data is successfully inserted into Table");
                    break;

                default:
                    Console.WriteLine("Invalid Table Number");
                    break;
            }

            connection.Close();
            Console.ReadLine();
        }
    }
}
