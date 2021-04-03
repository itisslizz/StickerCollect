
using System.Collections.Generic;
using StickerCollector.Core.Models;

namespace StickerCollector.Core
{
    public class Simulator
    {
        private readonly int _numberOfStickers;
        private readonly int _packSize;

        public Simulator(int numberOfStickers, int packSize){
            _numberOfStickers = numberOfStickers;
            _packSize = packSize;
        }

        public List<DataPoint> SimulateSingleUser()
        {
            var dataPoints = new List<DataPoint> { new DataPoint(0, 0) };
            var shop = new Shop(_numberOfStickers, _packSize);
            var user = new User(shop);
            var myStickers = 0;

            while (user.Album.Stickers.Count < _numberOfStickers)
            {
                user.BuyPack();
                user.OpenPack();
                if (user.Album.Stickers.Count > myStickers)
                {
                    dataPoints.Add(new DataPoint(user.PacksBought, user.Album.Stickers.Count));
                    myStickers = user.Album.Stickers.Count;
                }
            }

            return dataPoints;

        }
    }
}

