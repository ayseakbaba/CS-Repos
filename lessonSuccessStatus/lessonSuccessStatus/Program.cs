// Öğrencinin notuna göre geçme durumunu gösteren örnek

public class llessonSuccessStatus
{
    public enum HarfNotları
    {
        AA = 100,
        BA = 95,
        BB = 85,
        BC = 75,
        CC = 65,
        CD = 55,
        DD = 50,
        FF = 49,
    };
    public static void Main() {

        int not = (int)HarfNotları.FF;
        if (not == (int)HarfNotları.AA)
        {
            Console.WriteLine("Harf notunuz AA");
        }
        else if (not == (int)HarfNotları.BA)
        {
            Console.WriteLine("Harf notunuz BA");
        }
        else if (not == (int)HarfNotları.BB)
        {
            Console.WriteLine("Harf notunuz BB");
        }
        else if (not == (int)HarfNotları.BC)
        {
            Console.WriteLine("Harf notunuz BC");
        }
        else if (not == (int)HarfNotları.CC)
        {
            Console.WriteLine("Harf notunuz CC");
        }
        else if (not == (int)HarfNotları.CD)
        {
            Console.WriteLine("Harf notunuz CD");
        }
        else if (not == (int)HarfNotları.DD)
        {
            Console.WriteLine("Harf notunuz DD");
        }
        else {
            Console.WriteLine("Kaldınız");
        }
    }
}



