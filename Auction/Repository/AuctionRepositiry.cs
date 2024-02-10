using Auction_TestTaskCrazyChicken.Interface;
using Auction_TestTaskCrazyChicken.Models;
using Auction_TestTaskCrazyChicken_TestTaskCrazyChicken;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Auction_TestTaskCrazyChicken.Repository
{
    public class AuctionRepositiry : IAuction
    {
        private AppDBContent appDBContent;
        public AuctionRepositiry(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Auction> AllAuctions => appDBContent.Auctions;
        public Auction GetObjectAuction(int auctionId)
        {
            return appDBContent.Auctions
                .Include(a => a.Comments)
                .FirstOrDefault(p => p.id == auctionId);
        }

    }
}
