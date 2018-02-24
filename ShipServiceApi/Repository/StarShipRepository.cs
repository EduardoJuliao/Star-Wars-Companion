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
        public static async Task<IEnumerable<StarShipModel>> GetAllStarShips()
        {
            var serverUrl = "https://swapi.co/api/starships/";
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
            } while (result.Next != null);

            return ships;
        }
    }
}