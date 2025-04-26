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
    public class AboutController : Controller
    {
        private readonly CafeContext db;
        private readonly IValidator<About> validator;
        public AboutController(CafeContext db, IValidator<About> validator)
        {
            this.db = db;
            this.validator = validator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var about = db.Abouts.FirstOrDefault();
            return View(about);
        }
        [HttpPost]
        public async Task<IActionResult> Index(About p)
        {
            ValidationResult result = await validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }
            db.Abouts.Update(p);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}