using BasicOtomasyonSistemi;

namespace BasicOtomasyonSistemi
{//hayali bir otomasyon sistemimizin kullanıcının isteği doğrultusunda çoklu veri tabanına uyum sağlanması
    public interface IDatabase
    {
        int login(string username, string password);
        void close();
        void addValue(string value);
        void removeValue();
        void getValue();
    }

    class MYSqlDatabaseManager : IDatabase
    {
        private string value, userName = "mysql", password = "admin", mark = new string('-', 6);

        public void addValue(string value)
        {
            this.value = value;
        }

        public void close()
        {
            Console.WriteLine("{0}\n-> MySQL veritabanı bağlantınız başarılı " +
                "bir şekilde sonlandırıldı.\n{1}", mark, mark);
        }

        public void getValue()
        {
            if (value != null)
            {
                Console.WriteLine("{0}\n-> İsteğiniz doğrultuda hafızamdaki [{1}]" +
                    "verisini başarılı bir şekilde getirdim.\n{2}", mark, value, mark);
            }
            else
            {
                Console.WriteLine("{0}\n-> Veritabanı içerisisnde henüz bir veri" +
                    "bulunmuyor. Lütfen daha sonra tekrar deneyin.\n{1}", mark, mark);
            }
        }

        public int login(string username, string password)
        {
            if (username == this.userName && password == this.password)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void removeValue()
        {
            this.value = null;
            Console.WriteLine("{0}\n-> Veritabanı üzerinde tutulan veriler " +
                "başarılı bir şekilde silindi");
        }
    }

    class OracleDatabaseManager : IDatabase
    {
        private string value, userName = "oracle", password = "database", mark = new string('-', 6);

        public void addValue(string value)
        {
            this.value = value;
        }

        public void close()
        {
            Console.WriteLine("{0}\n-> Oracle veritabanı bağlantınız başarılı " +
                "bir şekilde sonlandırıldı.\n{1}", mark, mark);
        }

        public void getValue()
        {
            if (value != null)
            {
                Console.WriteLine("{0}\n-> İsteğiniz doğrultuda hafızamdaki [{1}]" +
                    "verisini başarılı bir şekilde getirdim.\n{2}", mark, value, mark);
            }
            else
            {
                Console.WriteLine("{0}\n-> Veritabanı içerisisnde henüz bir veri" +
                    "bulunmuyor. Lütfen daha sonra tekrar deneyin.\n{1}", mark, mark);
            }
        }

        public int login(string username, string password)
        {
            if (username == this.userName && password == this.password)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void removeValue()
        {
            this.value = null;
            Console.WriteLine("{0}\n-> Veritabanı üzerinde tutulan veriler " +
                "başarılı bir şekilde silindi");
        }
    }

    class DataBaseManager
    {
        private IDatabase database;
        private string mark = new string('-', 6);
        public DataBaseManager(IDatabase database)
        {
            this.database = database;
        }
        public DataBaseManager() { }
        public void loginDB()
        {
            string username, password;
            Console.WriteLine("{0}\n< Vertabanı Bağlantısı >\n" +
                               "{1}\n-> Kullanıcı Adı: ", mark, mark);
            username = Console.ReadLine();
            Console.WriteLine("-> Şifre: ");
            password = Console.ReadLine();
            Console.WriteLine(mark);

            if (database.login(username, password) == 1)
            {
                Menu();
            }
            else
            {
                Console.WriteLine("-> Bağlantı bilgilerini yanlış girdiniz" +
                                   "! Sistem kapatılıyor.\n{0}", mark);
            }
        }

        private void CloseDB()
        {
            database.close();
        }
        private void AddValue(string value)
        {
            database.addValue(value);
        }
        private void RemoveValue()
        {
            database.removeValue();
        }
        private void GetValue()
        {
            database.getValue();
        }
        private void Menu()
        {
            string value;
            int v;
            Console.WriteLine("<Veritabanı İşemleri>\n{0}", mark);
            Console.WriteLine("[1] - Veri Ekle\n[2] - Veri Sil\n[3] - Veri Getir\n[4] - Bağlantıyı Kes\n{0}", mark);
            Console.Write("-> Yapmak istediğiniz işlem: ");
            v = Convert.ToInt32(Console.ReadLine());

            switch (v)
            {
                case 1:

                    Console.Write("{0}\n-> Eklemek istediğiniz veri: ", mark);
                    value = Console.ReadLine();
                    AddValue(value);
                    Console.WriteLine(mark);
                    Console.Clear();
                    break;

                case 2:
                    Console.Clear();
                    RemoveValue();
                    Menu();
                    break;
                case 3:
                    Console.Clear();
                    GetValue();
                    Menu();
                    break;
                case 4:
                    CloseDB();
                    break;
            }
        }


    }
}
        



    internal class Program
    {
        static void Main(string[] args)
        {
        string mark = new string('-', 6);
        int value;
        DataBaseManager dataBase;

        Console.WriteLine("{0}\n< C# Interface Örnekleri >\n{1}", mark, mark);
        Console.WriteLine("[1] - Oracle Database Bağlantısı Kur\n[2] - Mysql Database Bağlantısı Kur\n{0}", mark);
        Console.Write("-> Kararınız: ");

        value = Convert.ToInt32(Console.ReadLine());
        switch (value)
        {
            case 1:
                dataBase = new DataBaseManager(new OracleDatabaseManager());
                dataBase.loginDB();
                break;
            case 2:
                dataBase = new DataBaseManager(new MYSqlDatabaseManager());
                dataBase.loginDB();
                break;
            default:
                Console.WriteLine(mark);
                break;
        }
    }
    }