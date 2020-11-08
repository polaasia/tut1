using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tutorial_01
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            

            if (args.Length == 0) {
                throw new ArgumentNullException("null http, provide one");
            }

            bool result = Uri.TryCreate(args[0], UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttps || uriResult.Scheme == Uri.UriSchemeHttp);

            if (!result) 
            {
                throw new ArgumentException("not correct uri");
            }

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(uriResult);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var matches = regex.Matches(content);


                if (matches == null)
                {
                    Console.WriteLine("No email addresses found");
                }
                else
                {
                    foreach (var match in matches)
                    {
                        Console.WriteLine(match.ToString());
                    }
                }

                
            }
            else 
            {
                Console.WriteLine("error during GET request");

            }
            
            httpClient.Dispose();
        }
    }
}
         
