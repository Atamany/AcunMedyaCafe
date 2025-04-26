using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly CafeContext _context;
        private readonly IValidator<Gallery> _validator;

        public GalleryController(CafeContext context, IValidator<Gallery> validator)
        {
            _context = context;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = _context.Galleries.ToList();
            return View(values);
        }
        public IActionResult AddGallery()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGallery(Gallery p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.Galleries.Add(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Gallery", new { area = "Admin" });
        }
        public IActionResult DeleteGallery(int id)
        {
            var value = _context.Galleries.Find(id);
            _context.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index", "Gallery", new { area = "Admin" });
        }
        public IActionResult UpdateGallery(int id)
        {
            var value = _context.Galleries.Find(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGallery(Gallery p)
        {
            ValidationResult result = await _validator.ValidateAsync(p);

            if (!result.IsValid)
            {
                result.Errors.ForEach(x => ModelState.AddModelError(x.PropertyName, x.ErrorMessage));
                return View(p);
            }

            _context.Galleries.Update(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Gallery", new { area = "Admin" });
        }
    }
}
