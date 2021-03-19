using System;
using System.Collections.Generic;

using StickerCollector.Core.Models;

namespace StickerCollector.Core
{
    public class Shop
    {
        private readonly Random _rand = new Random();
        private readonly int _stickerNumber;
        private readonly int _packSize;

        public Shop(int stickerNumber, int packSize)
        {
            _stickerNumber = stickerNumber;
            _packSize = packSize;
        }

        public Pack BuyPack()
        {
            var stickers = new List<Sticker>();
            for(var i = 0; i < _packSize; i++){
                stickers.Add(new Sticker(_rand.Next(_stickerNumber)));
            }
            return new Pack(stickers);

        }
    }
}
