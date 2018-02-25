using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleCompanion.Models;
using ConsoleCompanion.Service;

namespace ConsoleCompanion {
    class Program {
        static void Main (string[] args) {
            
            AppManager.Start();
            AppManager.Manage();
        }
    }
}