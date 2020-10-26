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

            var url = @"http://www.pja.edu.pl/dziekanat";

            using (var httpClient = new HttpClient())
            {


                using (var response = await httpClient.GetAsync(url))
                {
                    var content = await response.Content.ReadAsStringAsync();


                    var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                    var matches = regex.Matches(content);

                    foreach (var match in matches) //foreach tab tab
                    {
                        Console.WriteLine(match.ToString());
                    }

                }
            }
        }
         
    }
}
