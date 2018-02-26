using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCompanion.Helpers;
using ConsoleCompanion.Models;
using ConsoleCompanion.Service;

namespace ConsoleCompanion
{
    public class ShipManager
    {
        public async static Task ShowShips()
        {
            Console.WriteLine("Searching...");
            await GetAllShips((ships) =>
            {
                foreach (var ship in ships)
                    ObjectExtensions.PrintObject(ship);
            });

        }

        public static async Task ShowOneShip(int shipId)
        {
            var ship = await StarShipService.GetShip(shipId);
            if (ship == null)
            {
                Console.WriteLine($"Sorry, couldn't find ship with id: {shipId}");
            }
            else ObjectExtensions.PrintObject(ship);
        }

        public async static Task DownloadAllShips()
        {
            var success = false;

            Console.WriteLine("Downloading...");
            var ships = await StarShipService.GetAllShips();

            string folder = AppManager.DefaultDownloadFolder;

            while (!success && !Directory.Exists(folder))
            {
                Console.WriteLine("Please, specify the folder where we can download the ships:");
                folder = Console.ReadLine();

                try
                {

                    var fullPath = $@"{folder}\starships.csv";
                    Console.WriteLine("Writing to: " + fullPath);

                    await File.WriteAllTextAsync(fullPath, ships.ToCsv());
                    success = true;
                }
                catch (UnauthorizedAccessException)
                {
                    success = false;
                    Console.WriteLine("The application does not have acces to create a file in the selected path.");

                }
                catch (DirectoryNotFoundException)
                {
                    success = false;
                    Console.WriteLine("The application couldn't find the path inputed.");

                }
            }

            Console.WriteLine("Done!");
        }

        public async static Task ShipNumberStopAll()
        {
            var mglt = GetMGLT();
            Console.WriteLine("Searching...");
            await GetAllShips((ships) =>
            {
                foreach (var ship in ships)
                    ShowStopsInDistance(mglt, ship);
            });

        }

        public async static Task ShipNumberStop()
        {
            var mglt = GetMGLT();
            var ship = await GetShip();
            ShowStopsInDistance(mglt, ship);
        }

        private async static Task GetAllShips(Action<IEnumerable<StarShipModel>> afterFinished)
        {
            int page = 0;
            bool hasItems = false;
            do
            {
                page++;
                await StarShipService.GetAllShipsPaged(page)
                    .ContinueWith(task =>
                    {
                        hasItems = task.Result != null && task.Result.Any ();
                        afterFinished(task.Result);
                    });
            } while (hasItems);
        }

        private static double GetMGLT()
        {
            Console.WriteLine("Please, specify the length in MGLT: ");
            var mgltInput = Console.ReadLine();
            if (double.TryParse(mgltInput, out double mglt))
            {
                return mglt;
            }
            else
            {
                return GetMGLT();
            }
        }

        private async static Task<StarShipModel> GetShip()
        {
            Console.WriteLine("Please, specify the ship id: ");
            var idInput = Console.ReadLine();
            if (int.TryParse(idInput, out int id))
            {
                Console.WriteLine("Searching...");
                var ship = await StarShipService.GetShip(id);

                if (ship != null) return ship;

                Console.WriteLine("Couldn't find ship by id: " + id);
                return await GetShip();
            }
            else
            {
                Console.WriteLine("Please inform a valid MGLT number");
                return await GetShip();
            }
        }

        private static void ShowStopsInDistance(double mglt, StarShipModel ship)
        {
            ObjectExtensions.PrintObject(ship);
            if (ship.MGLTValue == 0)
            {
                Console.WriteLine($"The MGLT value for {ship.Name} is unknow.");
                Console.WriteLine("Please, select another ship.");
            }
            else
            {
                var stops = Math.Round(mglt / ship.MGLTTimesConsumable);
                Console.WriteLine($"To travle the distance of {mglt} the ship must make {stops} stops");
            }
        }

    }
}