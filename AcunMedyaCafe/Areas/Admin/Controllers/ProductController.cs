using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly CafeContext db;
        private readonly IValidator<Product> validator;
        public ProductController(CafeContext db, IValidator<Product> validator)
        {
            this.db = db;
            this.validator = validator;
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
        public async Task<IActionResult> AddProduct(Product p)
        {
            ValidationResult result = await validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }
            if (p.ImageFile != null)
            {
                var extension = Path.GetExtension(p.ImageFile.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                p.ImageFile.CopyTo(stream);
                p.ImageUrl = "/images/" + newImageName;
                db.Products.Add(p);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View(p);
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
        public async Task<IActionResult> UpdateProduct(Product p)
        {
            ValidationResult result = await validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }
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
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}
