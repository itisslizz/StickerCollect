using System.Collections.Generic;

namespace StickerCollector.Core.Models
{
    public class Sticker 
    {

        public Sticker(int number)
        { 
            Number = number;
        }

        public int Number { get; }
    }

    public class Album 
    {
        public Dictionary<int, Sticker> Stickers { get; set; } = new Dictionary<int, Sticker>();
    }

    public class Pack 
    {
        public List<Sticker> Stickers { get; }

        public Pack(List<Sticker> stickers) 
        {
            Stickers = stickers;
        }
    }
}