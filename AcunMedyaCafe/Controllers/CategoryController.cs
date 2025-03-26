using AcunMedyaCafe.Context;
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
    }
}
