using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShipServiceApi.Models;
using ShipServiceApi.Repository;

namespace ShipServiceApi.Controllers
{

    [Route("Home")]
     [Route("")]
    public class HomeController : Controller
    {
        [Route("Index")]
         [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}