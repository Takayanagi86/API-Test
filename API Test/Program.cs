using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API_Test
{
   

    class Program
    {
        private const string URL = "https://api.publicapis.org/entries?category=animals";

        public static async void GetProjects()
		{


            using (HttpClient client = new HttpClient())
            {
                new MediaTypeWithQualityHeaderValue("application/json");
                HttpResponseMessage response = client.GetAsync(URL).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                    var API = JsonConvert.DeserializeObject<RootObject>(responseBody);
                    Console.WriteLine(API);
                    var cats = API.Results;
                    Console.WriteLine(cats);
                    
                    foreach (var cat in API.Results.OrderBy( c => c.Description).Take(5))
                    {
                        Console.WriteLine(cat.Description);
                    }
                    foreach (var cat2 in cats.Where((c) => c.Cors == "unknown"))
                    {
                        Console.WriteLine(cat2.Api + " " + cat2.Description + " " + cat2.Cors);
                    }
                    var cat3 = cats.Count((c) => c.Cors == "unknown");
                    Console.WriteLine(cat3);
                    
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
                Console.WriteLine("Hello World!");

            }
        }
	
	static void Main(string[] args)
        {
			//Console.WriteLine("Hello World!");
			GetProjects();
			
		}
    }
}
