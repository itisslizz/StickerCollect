using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

using Panini.Core;


namespace Panini.Test
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
    }
}
