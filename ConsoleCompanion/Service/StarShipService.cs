using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using ConsoleCompanion.Models;
using Newtonsoft.Json;

namespace ConsoleCompanion.Service
{
    public class StarShipService
    {
        private static HttpClient Client = new HttpClient();
        private static readonly string ServerUrl = AppManager.Configuration["apiUrl"] + "/api/StarShip";


        public static bool CheckConnection()
        {
            using (var ping = new Ping())
            {
                try
                {
                    Client.GetAsync(AppManager.Configuration["apiUrl"]).Wait();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }
        public static async Task<IEnumerable<StarShipModel>> GetAllShips()
        {
            var response = await Client.GetAsync($"{ServerUrl}/list");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<StarShipModel>>(json);
            }
            else return default(IEnumerable<StarShipModel>);
        }

        public static async Task<IEnumerable<StarShipModel>> GetAllShipsPaged(int page = 1)
        {
            var response = await Client.GetAsync($"{ServerUrl}/list/{page}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<StarShipModel>>(json);
            }
            else return default(IEnumerable<StarShipModel>);
        }

        public static async Task<StarShipModel> GetShip(int shipId)
        {
            var response = await Client.GetAsync($"{ServerUrl}/{shipId}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StarShipModel>(json);
            }
            else return default(StarShipModel);
        }

        public static async Task<byte[]> GetAllShipsBytes()
        {
            var response = await Client.GetAsync($"{ServerUrl}/list");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync();
            }
            else return default(byte[]);
        }
    }
}