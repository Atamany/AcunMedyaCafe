using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly CafeContext db;
        public ProductController(CafeContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var values = db.Products.Include(x => x.Category).ToList();
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
        public IActionResult AddProduct(Product p)
        {
            if (p.ImageFile != null)
            {
                var extension = Path.GetExtension(p.ImageFile.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageFile.CopyTo(stream);
                p.ImageUrl = "/images/" + newImageName;
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult DeleteProduct(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var product = db.Products.Find(id);
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View(product);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            if (p.ImageFile != null)
            {
                var extension = Path.GetExtension(p.ImageFile.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageFile.CopyTo(stream);
                p.ImageUrl = "/images/" + newImageName;
            }
            db.Products.Update(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
