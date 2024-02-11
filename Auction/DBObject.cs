using Auction_TestTaskCrazyChicken.Models;
using Auction_TestTaskCrazyChicken_TestTaskCrazyChicken;
using Microsoft.EntityFrameworkCore;

namespace Auction_TestTaskCrazyChicken
{
    public static class DBObject
    {
        public static void Initial(AppDBContent context)
        {
            if (!context.Auctions.Any())
            {
                var auctions = new List<Auction>
                {
                    new Auction
                    {
                        name = "Test",
                        description = "Bayraktar chinazes",
                        number = 123456789,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddDays(6),
                        price = 10,
                        img = "/img/Bayraktar.jpg"
                    },
                    new Auction
                    {
                        name = "Test2",
                        description = "Samsa vkesnaia",
                        number = 576894376,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddDays(5),
                        price = 10,
                        img = "/img/samsa.jpg"
                    }
                };
                context.Auctions.AddRange(auctions);
                context.SaveChanges(); 
            }

            if (!context.Comments.Any())
            {
                var testAuctionId = context.Auctions.FirstOrDefault(a => a.name == "Test")?.id;
                var test2AuctionId = context.Auctions.FirstOrDefault(a => a.name == "Test2")?.id;

                var comments = new List<Comment>
                {
                    new Comment
                    {
                        nameOfCommentator = "Oleg",
                        time = DateTime.Now,
                        text = "Good samsa",
                        number = 987654321,
                        AuctionId = 2
                    },
                    new Comment
                    {
                        nameOfCommentator = "Mahmet",
                        time = DateTime.Now,
                        text = "Otrawilsa, samsa ne och",
                        number = 49376489,
                        AuctionId = 2
                    },
                    new Comment
                    {
                        nameOfCommentator = "Jack",
                        time = DateTime.Now,
                        number = 174563968,
                        text = "Bom Bom",
                        AuctionId = 1
                    },
                    new Comment
                    {
                        nameOfCommentator = "Mitia",
                        time = DateTime.Now,
                        number = 20958476,
                        text = "Kasha",
                        AuctionId = 1
                    }
                };
                context.Comments.AddRange(comments);
            }

            context.SaveChanges();
        }
    }
}
