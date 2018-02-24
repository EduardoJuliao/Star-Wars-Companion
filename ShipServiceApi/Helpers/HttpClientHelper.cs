using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShipServiceApi.Helpers
{
    public sealed class HttpClientHelper
    {
        public static async Task<T> GetFromApi<T>(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(content);
                }else{
                    throw new Exception("Couldn`t get the desired data from server.");
                }
            }
        }
    }
}