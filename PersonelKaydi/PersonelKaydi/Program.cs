namespace PersonelKaydi
{//10 personele ait numara,isim,telefon ve email bilgileri ayrı ayrı dizilerde tutan
 //aranan numaraya göre ilgili kişinin bilgilerini ekranda gösteren dizi örneği
    internal class Program
    {
        static void Main(string[] args)
        {
            string arananNum;
            string[] number = {"101", "102", "103", "104","105","106","107","108","109","110"};
            string[] name = {"Ayşe","Nusret", "Burhan", "Vaşit", "Yenes", "Abdü", "Yami", "Yusuf", "Sıdkı","Hatice"};
            string[] phoneNumber = { "111", "222", "333", "444", "555", "666", "777", "888", "999", "1000" };
            string[] email = {"a@gmail.com", "b@gmail.com", "c@gmail.com", "d@gmail.com", "e@gmail.com"
                             ,"f@gmail.com","g@gmail.com","h@gmail.com","i@gmail.com","j@gmail.com"};

            Console.Write("Personel No = ");
            arananNum = Console.ReadLine();
            int no = Array.IndexOf(number, arananNum); //IndexOf(diziAdı, Aranılan değer(STRING veya CHAR));
            Console.WriteLine("\nAranan Kişi : " + name[no] + "\nTelefon Numarası : " + phoneNumber[no] + "\nEmail : " + email[no]);

            /*  BENİM YAZDIĞIM KISIM (IndexOf'dan önce)
            for (int i = 0; i < number.Length; i++)
            {
                Console.WriteLine(number[arananNum - 1]);
                break;
            }
            for (int i = 0; i < name.Length; i++)
            {
                Console.WriteLine(name[arananNum - 1]);
                break;
            }
            for (int i = 0; i < phoneNumber.Length; i++)
            {
                Console.WriteLine(phoneNumber[arananNum - 1]);
                break;
            }
            for (int i = 0; i < email.Length; i++)
            {
                Console.WriteLine(email[arananNum -1]);
                break;
            }
            */

        }
    }
}