using System.Net.Http.Json;

namespace ProductsCatalogClientConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get products from some api


            string apiUri = "https://localhost:44303/api/Products";

            HttpClient client = new HttpClient();

            // add http header for json data
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var responseMessage = client.GetAsync(apiUri).Result;

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //var products = responseMessage.Content.ReadAsStringAsync().Result;

                var products = responseMessage.Content.ReadFromJsonAsync<List<Item>>().Result;

                //Console.WriteLine(products);

                foreach (var item in products)
                {
                    Console.WriteLine(item.name);
                }
            }

            //Console.WriteLine(products);

        }

        public class Item
        {
            public int id { get; set; }
            public string name { get; set; }
            public int price { get; set; }
            public string brand { get; set; }
            public bool inStock { get; set; }
            public string country { get; set; }
        }

    }
}
