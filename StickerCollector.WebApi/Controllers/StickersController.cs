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
        internal class DataPoint{

            public DataPoint(int x, int y){
                X = x;
                Y = y;
            }
            public int X { get; }
            public int Y { get; }
        }

        [HttpGet]
        public ActionResult GetSimulationData(int numberOfStickers, 
        int packSize)
        {
            var dataPoints = new List<DataPoint>{ new DataPoint(0,0) };
            var shop = new Shop(numberOfStickers, packSize);
            var user = new User(shop);
            var myStickers = 0;
            
            while(user.Album.Stickers.Count < numberOfStickers)
            {
                user.BuyPack();
                user.OpenPack();
                if (user.Album.Stickers.Count > myStickers){
                    dataPoints.Add(new DataPoint(user.PacksBought, user.Album.Stickers.Count));
                }
            }

            return Ok(dataPoints);
        }

    }
}
