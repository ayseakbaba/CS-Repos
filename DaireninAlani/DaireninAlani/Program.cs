namespace DaireninAlani
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const float pi  = (float)Math.PI;
            string r;
            float yaricap;

            Console.WriteLine("Yarıçap = ");
            r = Console.ReadLine();
            yaricap = Convert.ToSingle(r);


            Console.WriteLine("Dairenin Alanı = " + (pi * yaricap*yaricap));
            Console.WriteLine("Dairenin Çevresi = " + (2*pi*yaricap));
        }
    }
}