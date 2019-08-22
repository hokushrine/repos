using System;
using System.Linq;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers
{
    public class AuctionController : Controller
    {
        private BeltContext _dbContext;
        public AuctionController(BeltContext context)
        {
            _dbContext = context;
        }

        public int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set {  HttpContext.Session.SetInt32("UserId", (int)value); }
        }
        private User loggedInUser
        {
            get { return _dbContext.Users.FirstOrDefault(u => u.Id == UserSession); }
        }
        [HttpGet("dashboard")]
        public IActionResult Index()
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}
            
            var allAuctions = _dbContext.Auctions
                .Include(c => c.Creator)
                .Where(xp => xp.EndDate < DateTime.Now)
                .OrderByDescending(d => d.CreatedAt)
                .ToList();
            DashboardViewModel vm = new DashboardViewModel();
            vm.Auctions = allAuctions;
            return View(vm);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}
            return View();
        }

        // Create new auction
        [HttpPost("new")]
        public IActionResult Create(Auction newAuction)
        {
            if(ModelState.IsValid)
            {
                newAuction.StartingBid = newAuction.HighestBid;
                newAuction.Creator = loggedInUser;
                _dbContext.Auctions.Add(newAuction);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Auction");
            }
            return View("New");
        }

        [HttpGet("{AuctionId}")]
        public IActionResult Show(int AuctionId)
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}
             var Auction = _dbContext.Auctions
                .Include(p => p.Creator)
                .FirstOrDefault(p => p.Id == AuctionId);
            NewAuctionViewModel vm = new NewAuctionViewModel();
            vm.AuctionItem = Auction;
            return View(vm);
        }

        [HttpPost("create")]
        public IActionResult NewBid(NewAuctionViewModel modelData)
        {
            // Currently gives some linq query error
            // Show requires instances, so they need to be reinitialized to return View();
            // var Auction = _dbContext.Auctions
            //     .Include(c => c.Creator)
            //     .FirstOrDefault(a => a.Id == modelData.AuctionItem.Id);
            //     NewAuctionViewModel vm = new NewAuctionViewModel();
            //     vm.AuctionItem = Auction;

            if(ModelState.IsValid)
            {
                BidAssociation newBid = modelData.NewBidder;
                
                // Check if new bid is higher than the highest bid
                var topBid = _dbContext.Auctions.FirstOrDefault(u => u.Id == newBid.AuctionId);
                if(newBid.Bid > topBid.HighestBid)
                {
                    topBid.HighestBid = newBid.Bid;
                    newBid.UserId = loggedInUser.Id;
                    _dbContext.Add(newBid);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index", "Auction");
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet("delete/{AuctionId}")]
        public IActionResult Delete(int AuctionId)
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}

            // query for auction
            Auction toDelete = _dbContext.Auctions.FirstOrDefault(a => a.Id == AuctionId
                && a.UserId == loggedInUser.Id);
            
            // if null, redirect
            if(toDelete == null) {return RedirectToAction("Index", "Auction");}
            
            _dbContext.Auctions.Remove(toDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Auction");
        }

        public void Expire(Auction toExpire)
        {
            if(toExpire.EndDate > DateTime.Now)
            {
                toExpire.BidStatus = false;
                _dbContext.SaveChanges();
            }
        }

        public void TimeRemaining(Auction auctionTime)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan timeRemaining = currentTime - auctionTime.EndDate;
        }
    }
}