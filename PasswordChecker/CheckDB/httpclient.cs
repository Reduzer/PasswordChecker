using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace PasswordChecker.CheckDB
{
    /// <summary>
    /// This Class is for connecting with the api of the haveibeenpwned webside
    /// 
    /// </summary>
    public class httpclient
    {
        private static HttpClient client = new HttpClient();
        private static readonly string adress = "https://api.pwnedpasswords.com/range/";

        public static async Task request(string sInput)
        {
            try
            {
                string sFullAdress = adress + sInput.Substring(0, 5);

                Uri uFullAdress = new Uri(sFullAdress);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(uFullAdress);

                Console.ForegroundColor = ConsoleColor.Green;
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(uFullAdress))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        Console.WriteLine(responseBody);

                        Program.response = responseBody;
                    }

                    Console.WriteLine();
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine($"{e.Message}");
                }
            }
            catch(Exception e){
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Exception has been Caought!");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
