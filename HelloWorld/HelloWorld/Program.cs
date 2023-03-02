class HelloWorld
{
    static void Main(string[] args)
    {
        string ad;
        Console.WriteLine("Adınızı Girin: ");
        ad = Console.ReadLine(); // İnput almak için kullanılan yapı

        Console.WriteLine("Hoşgeldiniz, " + ad);
        Console.ReadKey();
    }
}
