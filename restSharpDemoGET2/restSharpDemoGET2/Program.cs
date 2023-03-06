using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft;

namespace restSharpDemoGET2
{//Bu örnekte json dosyasını özellikle belirterek 
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://reqres.in/"); //URL ve HTTP protokolünün olduğu kısım buraya
            var request = new RestRequest("/api/users?page=2", Method.Get);// Geriye kalan kısım endpointtir. Orası da buraya yazılır.
            //request.AddHeader("Accept", "application/json");
            //request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;
            Console.WriteLine(content);
            Console.ReadKey(true);
        }
    }
}
