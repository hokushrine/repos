using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BankAccountsProj.Models;

namespace BankAccountsProj.Controllers
{
    [Route("bank")]
    public class BankController : Controller
    {
        private bool inSession
        {
            get { return HttpContext.Session.GetInt32("userId") != null; }
        }
        private User loggedInUser
        {
            get
            {
                return _dbContext.Users.Include(u => u.UserTransactions)
                    .FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId"));
            }
        }
        private BankAccountContext _dbContext;
        public BankController(BankAccountContext context)
        {
            _dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            if(!inSession)
                return RedirectToAction("Login", "Home");

            var user = loggedInUser;
            ViewBag.User = user;
            ViewBag.Transactions = _dbContext.Transactions
                .OrderByDescending(t => t.CreatedAt)
                .Where(t => t.UserId == loggedInUser.UserId);
            return View();
        }
        [HttpPost("money")]
        public IActionResult Money(Transaction trans)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Transactions.Add(trans);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            var user = loggedInUser;
            ViewBag.User = user;
            ViewBag.Transactions = _dbContext.Transactions
                .OrderByDescending(t => t.CreatedAt)
                .Where(t => t.UserId == loggedInUser.UserId);
            return View("Index");
        }
    }
}