namespace Auction_TestTaskCrazyChicken.Models
{
    public class Comment
    {
        public int id { get; set; }
        public DateTime time { get; set; }
        public string nameOfCommentator { get; set; }
        public string text { get; set; }
        public Auction AuctionId { get; set; }
    }
}