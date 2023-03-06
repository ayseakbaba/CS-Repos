using System.Text.Json;

namespace basicWeatherForecast
{

    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelcius { get; set; }
        public string? Summary { get; set; }
    }

    internal class Program
    {
        /*Asenkron bir şekilde çalışmak istiyorsak bunu farklı bir class oluşturup yapmalıyız 
         * Bu sayede asıl main metodun thread döngüsünü bozmamış oluruz.
        public static async Task Main()
        {
            var weatherForcast = new WeatherForecast()
            {
                Date = DateTimeOffset.Parse("06.03.2023"),
                TemperatureCelcius = 32,
                Summary = "Hot"
            };

            string fileName = "weatherForecast.json";
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, weatherForcast);
            await createStream.DisposeAsync();
            Console.WriteLine(File.ReadAllText(fileName));
        }*/


        public static async void Main(string[] args)
        {
            var weatherForcast = new WeatherForecast()
            {
                Date = DateTimeOffset.Parse("06.03.2023"),
                TemperatureCelcius = 32,
                Summary = "Hot"
            };
            




            /* Bu kod ile bir JSON dosyası oluşturabiliriz
            string fileName = "weatherForecast.json";
            string jsonString = JsonSerializer.Serialize(weatherForcast);
            File.WriteAllText(fileName, jsonString);  
            Console.WriteLine(File.ReadAllText(fileName));

            */


            /* El ile girilmişi bir JSON verisini ekrana yazdıran kod
            Console.WriteLine(jsonString);
            kodun çıktısı
            {"Date":"2023-03-06T00:00:00+03:00","TemperatureCelcius":32,"Summary":"Hot"}
            */
        }
    }
}