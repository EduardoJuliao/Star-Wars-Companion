using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShipServiceApi.Models;
using ShipServiceApi.Repository;

namespace ShipServiceApi.Controllers {
    [Route ("api/[controller]")]
    public class StarShipController : Controller {
        [HttpGet]
        [Route ("list/{page:int?}")]
        public async Task<IEnumerable<StarShipModel>> GetShips (int? page) {
            return await StarShipRepository.GetStarShips (page);
        }

        [HttpGet]
        [Route ("{id:int}")]
        public async Task<StarShipModel> GetShip (int id) {
            return await StarShipRepository.GetStarShip (id);
        }
    }
}