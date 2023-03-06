using RestSharp;

namespace restSharpDemoGET {

    internal class Program
    {
        static void Main(string[] args)
        {
            //istek gönderilecek sitenin url'i
            string url = "https://jsonplaceholder.typicode.com/todos";

            //request gönderecek istemci
            var client = new RestClient(url);

            //Requestin oluşturulduğu kısım
            var request = new RestRequest();

            //Url'in en sonundaki 1'i silerek addparameter kullanarak kendim ekledim.
            ////1 yerine başka bir rakam yazdığımda sitede varsa o sayfanın bilgilerini de gösteriyor.
            request.AddParameter("id", "1");

            //Ne çeşit bir request metodu kullanılacak Get,Delete Patch vb
            var response = client.Execute(request);

            //Get ile çekilen site bilgileri
            Console.WriteLine(response.Content); 
        }
    }
}