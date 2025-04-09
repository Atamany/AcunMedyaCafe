using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Entities.Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
