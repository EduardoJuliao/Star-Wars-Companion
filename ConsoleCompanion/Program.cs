using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using ConsoleCompanion.Models;
using Newtonsoft.Json;

namespace ConsoleCompanion
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://localhost:5000/api/StarShip").GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var content = JsonConvert.DeserializeObject<IEnumerable<StarShipModel>>(json);
                    foreach(var ship in content.Where(x => x.MGLTTimesConsumable != 0 )){
                        Console.WriteLine($"{ship.Name}: {1000000 / ship.MGLTTimesConsumable}");
                    }

                }
            }
        }
    }
}
