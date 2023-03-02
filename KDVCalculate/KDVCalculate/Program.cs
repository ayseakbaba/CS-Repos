using System.Globalization;

namespace KDVCalculate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bu programın amacı fiyatı girilen bir ürünün kdv miktarını ve kdv'li fiyatını hesaplayıp kullanıcıya göstermektir.
            double kdv = 0.18;
            string answer;
            double price;
            double kdvMiktari;
            Console.WriteLine("Ürünün fiyatını girin");
            answer= Console.ReadLine();

            price = Convert.ToDouble(answer);
            kdvMiktari = price * kdv;
            price += kdvMiktari;
            Console.WriteLine("Ürünün %18'lik KDV miktarı= " + kdvMiktari);
            Console.WriteLine("Ürünün satış fiyatı = " + price);




            /*
               using System;
  class HelloWorld {
    static void Main(string[] args)
          {
              string sayi;
              Console.Write("Bir sayı girin: ");
              sayi = Console.ReadLine();
              double kdv = 0.18;
              
              Console.WriteLine("Girdiğiniz sayının %18 KDV'si: " + (Convert.ToDouble(sayi) * kdv) );
              Console.ReadKey();
          }
  }
             
             
             */


        }
    }
}