using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Auction_TestTaskCrazyChicken.Models;

namespace Auction_TestTaskCrazyChicken_TestTaskCrazyChicken
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
