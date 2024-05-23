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
                string sFullAdress = adress + sInput;

                Uri uFullAdress = new Uri(sFullAdress);

                Console.WriteLine(uFullAdress);

                WebRequest request = WebRequest.Create(sFullAdress);
                request.Credentials = CredentialCache.DefaultCredentials;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Console.WriteLine(response.StatusDescription);

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                Console.WriteLine(responseFromServer);

                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch(Exception e){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exception has been Caought!");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
