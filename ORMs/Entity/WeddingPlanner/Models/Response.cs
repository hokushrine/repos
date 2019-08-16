using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Response
    {
        public int ResponseId {get;set;}
        public int WeddingId {get;set;}
        public int UserId {get;set;}
        public User Guest {get;set;}
    }
}