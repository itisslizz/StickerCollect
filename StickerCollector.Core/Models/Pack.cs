using System.Collections.Generic;
namespace StickerCollector.Core.Models{
public class Pack 
    {
        public List<Sticker> Stickers { get; }

        public Pack(List<Sticker> stickers) 
        {
            Stickers = stickers;
        }
    }
} 