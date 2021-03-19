using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

using StickerCollector.Core;
using StickerCollector.Core.Models;



namespace StickerCollector.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Pack_Stickers_Should_Be_Correct_Number()
        {
            var shop = new Shop(669, 5);
            var pack = shop.BuyPack();
            pack.Stickers.Count.Should().Be(5);
        }
        
        [TestMethod]
        public void When_User_Buys_Pack_Should_Increase_Stat()
        {
            var shop = new Shop(669, 5);
            var user = new User(shop);
            user.BuyPack();
            user.PacksBought.Should().Be(1);
        }

        [TestMethod]
        public void When_User_Buys_Pack_Should_Add_To_Packs()
        {
            var shop = new Shop(669, 5);
            var user = new User(shop);
            user.BuyPack();
            user.Packs.Count.Should().Be(1);
        }
        
        [TestMethod]
        public void When_User_Opens_Pack_When_No_Packs_Should_Return_False()
        {
            var shop = new Shop(669, 5);
            var user = new User(shop);
            user.OpenPack().Should().BeFalse();
        }
        
        [TestMethod]
        public void When_User_Opens_Pack_When_No_Packs_Should_Return_True_And_Remove_Pack()
        {
            var shop = new Shop(669, 5);
            var user = new User(shop);
            user.BuyPack();
            user.OpenPack().Should().BeTrue();
            user.Packs.Count.Should().Be(0);
        }
        
        [TestMethod]
        public void When_User_Uses_Sticker_Should_Put_In_Album()
        {
            var shop = new Shop(669, 5);
            var user = new User(shop);
            var sticker = new Sticker(2);
            user.UseSticker(sticker);
            user.Album.Stickers.Count.Should().Be(1);

        }
        
        [TestMethod]
        public void When_User_Uses_Sticker_Already_In_Album_Should_Put_In_Stash()
        {
            var shop = new Shop(669, 5);
            var user = new User(shop);
            var sticker = new Sticker(2);
            user.UseSticker(sticker);
            user.UseSticker(sticker);
            user.Stash[2].Count.Should().Be(1);

        }
    }
}
