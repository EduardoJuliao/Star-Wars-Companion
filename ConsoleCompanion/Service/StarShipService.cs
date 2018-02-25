using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleCompanion.Models;
using Newtonsoft.Json;

namespace ConsoleCompanion.Service {
    public class StarShipService {
        private static HttpClient Client = new HttpClient ();

        public static async Task<IEnumerable<StarShipModel>> GetAllShips () {
            var response = await Client.GetAsync ("http://localhost:5000/api/StarShip/list");
            if (response.IsSuccessStatusCode) {
                var json = await response.Content.ReadAsStringAsync ();
                return JsonConvert.DeserializeObject<IEnumerable<StarShipModel>> (json);
            }
            else return default(IEnumerable<StarShipModel>);
        }

         public static async Task<IEnumerable<StarShipModel>> GetAllShipsPaged (int page = 1) {
            var response = await Client.GetAsync ("http://localhost:5000/api/StarShip/list/" + page);
            if (response.IsSuccessStatusCode) {
                var json = await response.Content.ReadAsStringAsync ();
                return JsonConvert.DeserializeObject<IEnumerable<StarShipModel>> (json);
            }
            else return default(IEnumerable<StarShipModel>);
        }

        public static async Task<byte[]> GetAllShipsBytes(){
             var response = await Client.GetAsync ("http://localhost:5000/api/StarShip/list");
            if (response.IsSuccessStatusCode) {
                return await response.Content.ReadAsByteArrayAsync();
            }
            else return default(byte[]);
        }
    }
}