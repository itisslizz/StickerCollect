using System.Collections.Generic;

namespace Panini.Core.Models
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
        public List<Sticker> Stickers { get; set; } = new List<Sticker>();
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