using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Auction_TestTaskCrazyChicken.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Auction_TestTaskCrazyChicken_TestTaskCrazyChicken
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {
            try
            {
                var databaseCreater = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreater != null)
                {
                    if (!databaseCreater.CanConnect())
                    {
                        databaseCreater.Create();
                    }
                    if (!databaseCreater.HasTables())
                    {
                        databaseCreater.CreateTables();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
