namespace YuzdeHesaplama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Amaç: Kullanıcının girdiği sayının yine kullanıcının girdiği yüzdesini bulmak
            string ansSayi;
            double sayi;

            string ansYuzde;
            double yuzde;

            Console.WriteLine("Bir sayı giriniz= ");
            ansSayi= Console.ReadLine();
            sayi = Convert.ToDouble(ansSayi);

            Console.WriteLine("Hesaplamak istediğiniz yüzde miktarı(örnek 0,34) = ");
            ansYuzde = Console.ReadLine();
            yuzde = Convert.ToDouble(ansYuzde);

            if (sayi<0)
            {
                Console.WriteLine("Lütfen pozitif bir sayı giriniz!");
            }
            else
            {
                if (yuzde <0 ||yuzde > 1)
                {
                    Console.WriteLine("Geçersiz yüzde değeri! Lütfen tekrar deneyin!");
                }
                else
                {
                    sayi = (sayi * yuzde);
                    Console.WriteLine("Sonuç= " + sayi);
                }
            }

        }
    }
}