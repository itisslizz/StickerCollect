
using System.Collections.Generic;
using StickerCollector.Core.Models;
using System.Linq;

namespace StickerCollector.Core
{
    public class Simulator
    {
        private readonly int _numberOfStickers;
        private readonly int _packSize;
        private readonly Shop _shop;

        public Simulator(int numberOfStickers, int packSize){
            _numberOfStickers = numberOfStickers;
            _packSize = packSize;
            _shop = new Shop(_numberOfStickers, _packSize);
        }

        public List<DataPoint> SimulateSingleUser()
        {
            var dataPoints = new List<DataPoint> { new DataPoint(0, 0) };
            var user = new User(_shop);
            var myStickers = 0;

            while (user.Album.Stickers.Count < _numberOfStickers)
            {
                user.BuyPack();
                user.OpenPack();
                if (user.Album.Stickers.Count > myStickers)
                {
                    dataPoints.Add(new DataPoint(user.PacksBought, user.Album.Stickers.Count));
                    myStickers = user.Album.Stickers.Count;
                }
            }

            return dataPoints;
        }

        public List<List<DataPoint>> SimulateMultipleUsers(int numUsers){
            if (numUsers == 1)
                return new List<List<DataPoint>>{SimulateSingleUser()};
            var result = new List<List<DataPoint>>();
            var users = new List<User>();
            for (var i = 0; i < numUsers; i++){
                result.Add(new List<DataPoint>());
                users.Add(new User(_shop));
            }

            var currentUserId = 0;
            var totalPacks = 0;
            while(users.Any(x => x.Album.Stickers.Count < _numberOfStickers))
            {
                var user = users[currentUserId];
                var oldAmount = user.Album.Stickers.Count;
                user.BuyPack();
                user.OpenPack();
                totalPacks = users.Sum(x => x.PacksBought);
                if (oldAmount < user.Album.Stickers.Count)
                {
                    result[currentUserId].Add(new DataPoint(totalPacks, user.Album.Stickers.Count));
                }
                for(var i = 0; i < numUsers; i++)
                {
                    if (users[i] == user)
                        continue;
                    var oldAmountBuddy = users[i].Album.Stickers.Count;
                    users[i].UseStash(user);
                    if (oldAmountBuddy < users[i].Album.Stickers.Count)
                    {
                        result[i].Add(new DataPoint(totalPacks, users[i].Album.Stickers.Count));
                    }
                }
                currentUserId = (currentUserId + 1) % numUsers;
            }
            foreach(var userResult in result){
                if (userResult.Last().X != totalPacks){
                    userResult.Add(new DataPoint(totalPacks, _numberOfStickers));
                }
            }

            return result;
        }
    }
}

