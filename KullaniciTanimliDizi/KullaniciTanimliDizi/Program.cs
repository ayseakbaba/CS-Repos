namespace KullaniciTanimliDizi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boyut;
            Console.WriteLine("Şu ana kadar kaç tane şehir gezdim? = ");
            boyut = Convert.ToInt32(Console.ReadLine());

            //kullanıcının istediği boyutta
            string[] sehirler = new string[boyut];


            for (int i = 0; i < boyut; i++)
            {
                Console.WriteLine("Gezdiğim " + (i+1) +". şehir: ");
                sehirler[i] = Console.ReadLine();
            }
        }
    }
}