using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _DefaultGalleryComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultGalleryComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Galleries.ToList();
            return View(value);

        }
    }
}
