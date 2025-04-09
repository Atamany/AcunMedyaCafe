using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Controllers
{
    public class ProductController : Controller
    {

        private readonly CafeContext db;
        public ProductController(CafeContext db) { 
            this.db = db;
        }
        public IActionResult Index()
        {
            var values = db.Products.Include(x=>x.Category).ToList();
            return View(values);
        }
    }
}
