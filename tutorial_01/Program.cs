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
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(args[0]);

            if (response is null) {
                throw new ArgumentNullException("null http, provide one");
            }

            if(response.IsSuccessStatusCode)
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
            httpClient.Dispose();
        }
    }
}
         
