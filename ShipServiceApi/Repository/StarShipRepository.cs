using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShipServiceApi.Helpers;
using ShipServiceApi.Models;

namespace ShipServiceApi.Repository
{
    public sealed class StarShipRepository
    {
        private const string ServerUrl = "https://swapi.co/api/starships";

        public static async Task<IEnumerable<StarShipModel>> GetStarShips(int? page = null)
        {
            var serverUrl = $"{ServerUrl}{(page != null ? "/?page=" + (int)page : "")}";
            List<StarShipModel> ships = new List<StarShipModel>();
            StarWarsContent<IEnumerable<StarShipModel>> result = null;
            do
            {
                result = await HttpClientHelper.GetFromApi<StarWarsContent<IEnumerable<StarShipModel>>>(serverUrl);
                if (result != null)
                {
                    serverUrl = result.Next;
                    ships.AddRange(result.Results);
                }
            } while (result != null && result.Next != null && page == null);

            return ships;
        }

        public static async Task<StarShipModel> GetStarShip(int id){
            return await HttpClientHelper.GetFromApi<StarShipModel>($"{ServerUrl}/{id}");
        }
    }
}