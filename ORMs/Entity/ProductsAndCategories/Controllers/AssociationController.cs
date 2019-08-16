using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
namespace ProductsCategories.Controllers
{
    public class AssociationController : Controller
    {
        private PCContext _dbContext;
        public AssociationController(PCContext context)
        {
            _dbContext = context;
        }
        [HttpPost("product/{isProduct}")]
        public IActionResult Create(Association newAssoc)
        {
           
            _dbContext.Associations.Add(newAssoc);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
    }
}