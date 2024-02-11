using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace Auction_TestTaskCrazyChicken.Models
{
    public class Auction
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int number { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        [JsonIgnore]
        public List<Comment> Comments { get; set; }
    }
}
