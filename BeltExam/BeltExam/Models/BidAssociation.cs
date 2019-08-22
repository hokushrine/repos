using System;
using System.ComponentModel.DataAnnotations;
using BeltExam.Models;

namespace BeltExam.Models
{
    public class BidAssociation
    {
        [Key]
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public int UserId { get; set; }
        public int Bid { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        public User Bidder { get; set; }
        public Auction Auction { get; set; }
        
    }
}