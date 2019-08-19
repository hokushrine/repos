using Microsoft.AspNetCore.Mvc;
using E_CommerceNoStripe.Models;
using System.Linq;

namespace E_CommerceNoStripe
{
    public class ProductController : Controller
    {
        private EcomContext _dbContext;
        public ProductController(EcomContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            var allProducts = _dbContext.Products.ToList();
            ProductViewModel vm = new ProductViewModel();
            vm.Products = allProducts;
            return View("ProductIndex", vm);
        }

        [HttpPost("product/create")]
        public IActionResult Create(ProductViewModel modelData)
        {
            if(ModelState.IsValid)
            {
                Product newProduct = modelData.NewProduct;

                _dbContext.Add(newProduct);
                _dbContext.SaveChanges();
                
            return RedirectToAction("Index", "Product");
            }
            return View("Index", "Product");
        }
    }
}