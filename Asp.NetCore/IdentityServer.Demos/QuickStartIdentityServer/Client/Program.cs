using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientCredential().GetAwaiter().GetResult();
            ResourceOwnerPassword().GetAwaiter().GetResult();
        }


        private static async Task ClientCredential()
        {

            var discoveryResponse = await DiscoveryClient.GetAsync("http://localhost:5000");
            var tokenclient = new TokenClient(discoveryResponse.TokenEndpoint, "client1", "secret");
            var token = await tokenclient.RequestClientCredentialsAsync("api1");
            if (token.IsError)
            {
                Console.WriteLine(token.Error);
                return;
            }

            Console.WriteLine(token.Json);


            var client = new HttpClient();
            client.SetBearerToken(token.AccessToken);
            var response = await client.GetAsync("http://localhost:5001/api/identity/index");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                return;
            }

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(JArray.Parse(content));


        }


        private static async Task ResourceOwnerPassword()
        {
            var discoveryResponse = await DiscoveryClient.GetAsync("http://localhost:5000");
            var tokenclient = new TokenClient(discoveryResponse.TokenEndpoint, "ro.client", "secret");
            var token = await tokenclient.RequestResourceOwnerPasswordAsync("tom", "tom123", "api1");

            if (token.IsError)
            {
                Console.WriteLine(token.Error);
                return;
            }

            Console.WriteLine(token.Json);


            var client = new HttpClient();
            client.SetBearerToken(token.AccessToken);
            var response = await client.GetAsync("http://localhost:5001/api/identity/index");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                return;
            }

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(JArray.Parse(content));
        }
    }
}
