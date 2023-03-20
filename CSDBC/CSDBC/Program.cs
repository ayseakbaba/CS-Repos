using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CSDBC
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=C:\uyeKaydi.db ";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            SQLiteCommand cmd = new SQLiteCommand(connectionString);


        }
    }
}
