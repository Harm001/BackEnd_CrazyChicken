using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace Auction_TestTaskCrazyChicken.Models
{
    public class Auction
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        //public ICollection<Comment> Comments { get; set; }
    }
}
