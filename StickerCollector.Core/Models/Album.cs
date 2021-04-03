using System.Collections.Generic;

namespace StickerCollector.Core.Models
{
    public class Album 
    {
        public Dictionary<int, Sticker> Stickers { get; set; } = new Dictionary<int, Sticker>();
    }
}