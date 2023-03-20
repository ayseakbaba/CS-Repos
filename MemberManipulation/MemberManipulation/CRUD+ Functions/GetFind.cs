using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManipulation.CRUD__Functions
{
    public class GetFind
    {
        //A method that finds the member with the help of the member ID and lists its information
        public static void Find()
        {
            Console.Write("Member ID: ");
            string id = Console.ReadLine();

            //Project and Database Connection
            string connectionString = @"Data Source=C:\Users\aysea\Documents\DB Browser for SQLite\memberRegister.db ";
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
    }
}
