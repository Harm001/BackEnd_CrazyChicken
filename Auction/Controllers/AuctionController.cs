using Auction_TestTaskCrazyChicken.Interface;
using Auction_TestTaskCrazyChicken.Models;
using Auction_TestTaskCrazyChicken.ViewModel;
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
    }
}
