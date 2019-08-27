using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FEHClone.Models;

namespace FEHClone.Controllers
{
    public class SkillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // TODO: Implement New
        [HttpGet("skill/new")]
        public IActionResult New()
        {
            return View();
        }
        // TODO: Implement Create
        [HttpGet("skill/create")]
        public IActionResult Create()
        {
            return View();
        }
        // TODO: Implement Show
        // TODO: Implement Edit
        // TODO: Implement Delete
    }
}
