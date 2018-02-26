using System;
using System.IO;
using System.Threading;
using ConsoleCompanion.Service;
using Microsoft.Extensions.Configuration;

namespace ConsoleCompanion {
    public class AppManager {
        public static string DefaultDownloadFolder { get; set; }
        public static IConfiguration Configuration { get; set; }

        public static void Start () {
            Configuration =  new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build(); 

            Console.BufferHeight = 500;

            while(!StarShipService.CheckConnection()){
                Console.Clear();
                Console.WriteLine("The empire have cut off our connection to the server!");
                Console.WriteLine("Trying again in 3 second.");
                Thread.Sleep(3000);
            }
        }

        public static void End () {
            Console.WriteLine ("May the force be with you!");
        }

        public static void Manage () {
            ConsoleKey pressedKey;
            do {
                Console.Clear ();
                ShowMenu ();
                pressedKey = Console.ReadKey (true).Key;
                HandleKey (pressedKey);
            } while (pressedKey != ConsoleKey.Escape);
            End ();
        }

        static void ShowMenu () {
            Console.WriteLine ("\t\tMENU\t\t");
            Console.WriteLine ("Press the menu key to access a functionality");
            Console.WriteLine ("Press ESC key to exit.");
            Console.WriteLine ("1 - Show all whips");
            Console.WriteLine ("2 - Download all Ships");
            Console.WriteLine ("3 - Check stops for desired distance.");
            Console.WriteLine ("4 - Check stops for desired distance - all ships.");
            Console.WriteLine ("9 - Access application options");
        }

        static void HandleKey (ConsoleKey key) {
            if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1) {
                ShipManager.ShowShips().Wait();
            }else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2) {
                ShipManager.DownloadAllShips().Wait();
            } else if (key == ConsoleKey.D3 || key == ConsoleKey.NumPad3){
                ShipManager.ShipNumberStop().Wait();
            } else if (key == ConsoleKey.D4 || key == ConsoleKey.NumPad4){
                ShipManager.ShipNumberStopAll().Wait();
            } else if (key == ConsoleKey.Escape){
                return;
            } else{
                Console.WriteLine ("Unrecognized key, please, try again.");
            }

            Console.WriteLine("Press any key to go back to menu.");
            Console.ReadKey();
        }
    }
}