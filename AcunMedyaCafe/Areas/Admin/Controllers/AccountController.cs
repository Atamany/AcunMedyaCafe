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
    public class AccountController : Controller
    {
        private readonly CafeContext db;
        private readonly IValidator<Entities.Admin> validator;
        public AccountController(CafeContext db, IValidator<Entities.Admin> validator)
        {
            this.db = db;
            this.validator = validator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var id = HttpContext.Request.Cookies["AdminId"];
            var user = int.Parse(id);
            var admin = db.Admins.Find(user);
            return View(admin);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Entities.Admin p)
        {
            ValidationResult result = await validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }
            db.Admins.Update(p);
            await db.SaveChangesAsync();
            return RedirectToAction("Logout", "Login", new { area=""});
        }
    }
}