namespace Panini.Core
{
    using Panini.Core.Models;
    using System.Collections.Generic;
    using System.Linq;


    public class User
    {
        public Album Album { get; set; } = new Album();

        public Dictionary<int, List<Sticker>> Stash = new Dictionary<int, List<Sticker>>();

        public int PacksBought = 0;

        private readonly Shop _myShop;

        public List<Pack> Packs { get; set; } = new List<Pack>();

        public User(Shop myShop)
        {
            _myShop = myShop;
        }

        public void BuyPack()
        {
            var pack = _myShop.BuyPack();
            PacksBought++;
            Packs.Add(pack);
        }

        public bool OpenPack()
        {
            var pack = Packs.FirstOrDefault();
            if (pack == null)
                return false;
            else
                Packs.Remove(pack);

            foreach(var sticker in pack.Stickers)
            {
                UseSticker(sticker);
            }
            return true;
        }

        public void UseSticker(Sticker sticker)
        {
            if (Album.Stickers.TryGetValue(sticker.Number, out var existingSticker))
            {
                AddStickerToStash(sticker);
            }
            else 
                Album.Stickers[sticker.Number] = sticker;

        }

        private void AddStickerToStash(Sticker sticker)
        {
            if (Stash.TryGetValue(sticker.Number, out var stickerStash)){
                stickerStash.Add(sticker);
            } else {
                Stash[sticker.Number] = new List<Sticker>(){sticker};
            }

        }

    }
    
}