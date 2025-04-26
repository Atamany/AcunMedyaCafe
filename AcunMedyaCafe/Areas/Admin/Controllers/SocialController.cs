using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SocialController : Controller
    {
        private readonly CafeContext _context;
        private readonly IValidator<Social> _validator;

        public SocialController(CafeContext context, IValidator<Social> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.Socials.ToList();
            return View(values);
        }
        public IActionResult AddSocial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSocial(Social p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.Socials.Add(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Social", new { area = "Admin" });
        }
        public IActionResult DeleteSocial(int id)
        {
            var value = _context.Socials.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index", "Social", new { area = "Admin" });
        }
        public IActionResult UpdateSocial(int id)
        {
            var value = _context.Socials.Find(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocial(Social p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.Socials.Update(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Social", new { area = "Admin" });
        }
    }
}
