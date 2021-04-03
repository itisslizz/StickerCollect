using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StickerCollector.Core;


namespace StickerCollector.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StickersController : ControllerBase
    {

        private readonly Simulator _simulator; 
        public StickersController(Simulator simulator)
        {
            _simulator = simulator;
        }
        [HttpGet]
        public ActionResult GetSimulationData(int numUsers)
        {
            if (numUsers < 1 || numUsers > 20)
                return BadRequest("Too many users specified. Choose in the range between 0 and 20");
            return Ok(_simulator.SimulateMultipleUsers(numUsers));
        }


    }
}
