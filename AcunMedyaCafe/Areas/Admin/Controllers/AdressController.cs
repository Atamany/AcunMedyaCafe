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
    public class AdressController : Controller
    {
        private readonly CafeContext db;
        private readonly IValidator<Adress> validator;
        public AdressController(CafeContext db, IValidator<Adress> validator)
        {
            this.db = db;
            this.validator = validator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Adress = db.Adresses.FirstOrDefault();
            return View(Adress);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Adress p)
        {
            ValidationResult result = await validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }
            db.Adresses.Update(p);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Adress", new { area = "Admin" });
        }
    }
}