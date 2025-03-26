using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CafeContext _context;

        public CategoryController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            _context.Categories.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UpdateCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category p)
        {
            _context.Categories.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
