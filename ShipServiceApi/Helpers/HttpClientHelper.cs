using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShipServiceApi.Helpers {
    public sealed class HttpClientHelper {
        private static HttpClient Client = new HttpClient ();

        public static async Task<T> GetFromApi<T> (string url) {
            var response = await Client.GetAsync (url);
            if (response.IsSuccessStatusCode) {
                var content = await response.Content.ReadAsStringAsync ();
                return JsonConvert.DeserializeObject<T> (content);
            } else {
                return default(T);
            }
        }
    }
}