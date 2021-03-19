namespace Panini.Core
{
    using Panini.Core.Models;
    using System.Collections.Generic;


    public class User
    {
        public Album Album { get; set; } = new Album();

        public Dictionary<int, List<Sticker>> Stash = new Dictionary<int, List<Sticker>>();

        public int PacksBought = 0;

        private readonly Shop _myShop;

        private List<Pack> _packs = new List<Pack>();

        public User(Shop myShop)
        {
            _myShop = myShop;
        }

        public void BuyPack()
        {
            var pack = _myShop.BuyPack();
            PacksBought++;
            _packs.Add(pack);
        }

    }
    
}