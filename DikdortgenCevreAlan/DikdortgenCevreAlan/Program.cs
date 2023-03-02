using System;

namespace DikdortgenCevreAlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string kisa;  
            string uzun;

            Console.WriteLine("1.Kenar= ");
            kisa = Console.ReadLine();

            Console.WriteLine("3.Kenar= ");
            uzun = Console.ReadLine();

            Console.WriteLine("Çevre= " +( Convert.ToDouble(kisa) *2 + Convert.ToDouble(uzun) *2));

            Console.WriteLine("Alan= " + (Convert.ToDouble(kisa) * Convert.ToDouble(uzun)));
        }
    }
}