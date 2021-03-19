using System;

namespace StickerCollector.Console
{
    using StickerCollector.Core;
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello You, Let's fill an album");
            System.Console.WriteLine("How many stickers in a pack?");
            var packSize = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("How many different stickers exist?");
            var numberOfStickers = int.Parse(System.Console.ReadLine());
            var shop = new Shop(numberOfStickers, packSize);

            var user = new User(shop);
            while(user.Album.Stickers.Count < numberOfStickers)
            {
                user.BuyPack();
                user.OpenPack();
                System.Console.WriteLine($"Packs Bought: {user.PacksBought}");
                System.Console.WriteLine($"Stickers in Album: {user.Album.Stickers.Count}");
                System.Console.WriteLine($"======================================");
                
            }
            System.Console.WriteLine($"You had to buy {user.PacksBought} packs");

        }
    }
}
