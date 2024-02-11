namespace Auction_TestTaskCrazyChicken.Models
{
    public class Auction
    {
        public Auction(int idLot, string name, string description, int lastBid, DateTime startDate, int timerCount)
        {
            this.idLot = idLot;
            this.name = name;
            this.description = description;
            this.lastBid = lastBid;
            this.startDate = startDate;
            this.timerCount = timerCount;
        }

        /*
let lastBid = items?.price;
 let timerCount = items?.timerCount;
 let idLot = id;
 let startDate = items?.date;
 let lotName = items?.name;
 let description = items?.description;
*/

        public int idLot { get; set; }
        public string name { get; set; }
        public string description {  get; set; }
        public int lastBid { get; set; }
        public DateTime startDate { get; set; }
        public int timerCount { get; set; }


    }
}
