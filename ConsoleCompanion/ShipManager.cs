using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCompanion.Helpers;
using ConsoleCompanion.Service;

namespace ConsoleCompanion {
    public class ShipManager {
        public async static Task ShowShips () {

            int page = 0;
            bool hasItems = false;
            do {
                page++;

                await StarShipService.GetAllShipsPaged (page)
                    .ContinueWith (ships => {
                        hasItems = ships.Result != null && ships.Result.Any ();
                        foreach (var ship in ships.Result) {
                            Console.WriteLine ("Ship Info:");
                            Console.WriteLine ($"Name: {ship.Name}");
                            Console.WriteLine ($"Mega Light: {ship.MGLT}");
                            Console.WriteLine ("+-------------------------------------+");
                        }
                    });
            } while (hasItems);
        }

        public async static Task DownloadAllShips () {
            string folder = AppManager.DefaultDownloadFolder;

            while (!Directory.Exists (folder))
            {
                Console.WriteLine ("Please, specify the folder where we can download the ships:");
                folder = Console.ReadLine ();
            }

            Console.WriteLine("Downloading...");
            var ships = await StarShipService.GetAllShips ();

            Console.WriteLine("Writing...");

            try{
                await File.WriteAllTextAsync ($@"{folder}\starships.csv", ships.ToCsv());
            }catch(UnauthorizedAccessException){
                Console.WriteLine("The application does not have acces to create a file in the selected path.");
            }
            

            Console.WriteLine("Done!");
        }

    }
}