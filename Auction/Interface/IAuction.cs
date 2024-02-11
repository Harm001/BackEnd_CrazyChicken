using Auction_TestTaskCrazyChicken.Models;
using System.Runtime.InteropServices;

namespace Auction_TestTaskCrazyChicken.Interface
{
    public interface IAuction
    {
        IEnumerable<Auction> AllAuctions {  get; }
        Auction GetObjectAuction(int auctionId);
        void AddAuction(Auction auction);
        Task AddComment(Comment comment);
    }
}
