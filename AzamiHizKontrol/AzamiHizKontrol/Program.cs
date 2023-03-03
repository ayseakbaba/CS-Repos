namespace AzamiHizKontrol
{//hızı düzenli aralıkda yükselen bir otomobilin hızı 80’i aştığında uyarı almasına yarayan program

    enum ArabaModel
    {
        kamyonet,
        minibus,
        otomobil,
        ticariArac
    };

    public delegate void HizHandler(object sender, HizArgs args);

    public class HizArgs
    {
        private int guncelHiz;
        public DateTime Zaman
        {
            get { return DateTime.Now; }
        }

        public int GuncelHiz
        {
            get { return guncelHiz;}
        }

        public HizArgs(int guncelHizi)
        {
            guncelHiz = guncelHizi;
        }
    }

    class Otomobil
    {
        private int hiz;
        private ArabaModel model;
        public event HizHandler HizAsildi; //Event oluşturuldu
        public ArabaModel Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Hiz
        {
            get { return hiz; }
            set
            {
                if (hiz >= 80 && HizAsildi != null)
                {
                    HizAsildi(this, new HizArgs(value));
                }
                hiz = value;
            }
        }

    }

    class HizAsildiEventArgs : EventArgs
    {
        private int guncelSurat;
        public int GuncelSurat
        {
            get { return guncelSurat; }
            set { guncelSurat = value;}
        }

        public HizAsildiEventArgs(int gSurat)
        {
            guncelSurat = gSurat;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Otomobil arabam = new Otomobil();
            arabam.HizAsildi += new HizHandler(arabam_HizAsildi);
            for (int i = 70; i < 90; i+= 5)
            {
                arabam.Hiz = i;
                Console.WriteLine("Hızımız, {0}", arabam.Hiz);
                Thread.Sleep(1000);
            }
        }

        static void arabam_HizAsildi(object sender , HizArgs args)
        {
            Console.WriteLine("Hız sınırı aşıldı..." + args.Zaman + ".");
        }
    }
}