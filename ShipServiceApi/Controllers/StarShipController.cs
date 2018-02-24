using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShipServiceApi.Models;
using ShipServiceApi.Repository;

namespace ShipServiceApi.Controllers
{
     [Route("api/[controller]")]
    public class StarShipController : Controller
    {
        [HttpGet]
        public IEnumerable<StarShipModel> GetShips()
        {
            return StarShipRepository.GetAllStarShips().GetAwaiter().GetResult();
        }
    }
}