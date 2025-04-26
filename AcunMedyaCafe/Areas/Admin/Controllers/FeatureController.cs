using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly CafeContext db;
        private readonly IValidator<Feature> validator;
        public FeatureController(CafeContext db, IValidator<Feature> validator)
        {
            this.db = db;
            this.validator = validator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Feature = db.Features.FirstOrDefault();
            return View(Feature);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Feature p)
        {
            ValidationResult result = await validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }
            db.Features.Update(p);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }
    }
}