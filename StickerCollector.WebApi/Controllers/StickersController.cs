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
    [Route("[controller]")]
    public class StickersController : ControllerBase
    {

        [HttpGet]
        public ActionResult GetSimulationData(int numberOfStickers, 
        int packSize)
        {
            var dataPoints = new List<List<int>>();
            var shop = new Shop(numberOfStickers, packSize);
            var user = new User(shop);

            while(user.Album.Stickers.Count < numberOfStickers)
            {
                user.BuyPack();
                user.OpenPack();
                dataPoints.Add(new List<int>{user.PacksBought, user.Album.Stickers.Count});
            }

            return Ok(dataPoints);
        }

    }
}
