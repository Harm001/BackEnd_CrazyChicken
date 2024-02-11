using Auction_TestTaskCrazyChicken.Interface;
using Auction_TestTaskCrazyChicken.Models;
using Auction_TestTaskCrazyChicken.ViewModel;
using Auction_TestTaskCrazyChicken_TestTaskCrazyChicken;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Auction_TestTaskCrazyChicken.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuctionController : ControllerBase
    {
        private readonly IAuction _auctionRepository;

        public AuctionController(IAuction auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

       

        // GET: /Auction
        [HttpGet]
        public IActionResult GetAllAuctions()
        {
            var auctions = _auctionRepository.AllAuctions;

            return Ok(auctions);
        }

        // GET: /Auction/{id}
        [HttpGet("{id}")]
        public IActionResult GetAuctionById(int id)
        {
            var auction = _auctionRepository.GetObjectAuction(id);

            if (auction == null)
            {
                return NotFound();
            }

            return Ok(auction);
        }
        [HttpPost("GetId/{id}")]
        public IActionResult GetId (int id)
        {
            return Ok(id);
        }

        // POST: /Auction
        [HttpPost("Add")]
        public IActionResult AddAuction([FromBody][Bind("id,name,price,discription,img")] Auction auction)
        {
             _auctionRepository.AddAuction(auction);
             return Ok(auction);
        }

        [HttpGet("getcomments/{id}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var auction = _auctionRepository.GetObjectAuction(id);

            return Ok(JsonConvert.SerializeObject(auction.Comments));
        }

        [HttpPost("newComment/{id}")]
        public async Task<IActionResult> AddComment([FromBody] NewCommentPostModel newComment, [FromRoute] int id)
        {
            var auction = _auctionRepository.GetObjectAuction(id);
            if (auction == null)
            {
                return NotFound();
            }
            Comment comment = new Comment();
            comment.AuctionId = id;
            comment.text = newComment.desc;
            comment.time = DateTime.Now;
            comment.nameOfCommentator = newComment.name + " " + newComment.surname;


            await _auctionRepository.AddComment(comment);

            return Ok();
        }

        [HttpPost("UpdatePrice/{id}")]
        public IActionResult UpDatePrice(int id, [FromBody] int newPrice)
        {
            var auction = _auctionRepository.GetObjectAuction(id);

            if (auction == null)
            {
                return NotFound();
            }

            auction.price = newPrice;
            _auctionRepository.UpdateAuction(auction);
            return Ok(auction);
        }
    }
}
