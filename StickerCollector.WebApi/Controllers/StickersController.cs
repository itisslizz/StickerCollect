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
        public ActionResult GetSimulationData()
        {
            return Ok(_simulator.SimulateSingleUser());
        }

    }
}
