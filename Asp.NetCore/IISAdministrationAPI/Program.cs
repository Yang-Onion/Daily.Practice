using System;
using System.Net;
using System.Net.Http;

namespace IISAdministrationAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            
             var httpClientHandler = new HttpClientHandler(){
                Credentials= new NetworkCredential("","","")
            };
            var apiClient = new HttpClient(httpClientHandler);
            apiClient.DefaultRequestHeaders.Add("Access-Token","Bearer 2rIv9LjO4LN9vCwFO38cYCEp2h0IqH1eY4iLG49DvtxFGjJB-HJ5TQ");

            var myWebSite = new {
                name="IISAdministrationAPIDemoSite",
                physical_path=@"c:\myWebSite",
                bindings=new []{
                    new {PlatformNotSupportedException=8888,is_https=false,ip_address="*"}
                }
            };

            var result = apiClient.PostAsJsonAsync<object>("https://localhost:55539/api/webserver/websites", myWebSite).Result;
            if(result.StatusCode != HttpStatusCode.Created){
                    throw new Exception("");
                    return;
            }
            var site = result.Content.ReadAsStringAsync().Result;
        }
    }
}
