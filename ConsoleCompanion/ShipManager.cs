using System;
using System.Threading.Tasks;
using ConsoleCompanion.Service;

namespace ConsoleCompanion {
    public class ShipManager {
        public static void ShowShips () {
            var page = 1;

            var taskMehtod =  StarShipService.GetAllShipsPaged (page);
            
            taskMehtod.ContinueWith(task => {
                foreach (var ship in task.Result) {
                    Console.WriteLine ($"{ship.Name}");
                }
                page++;
            });
        }
    }
}