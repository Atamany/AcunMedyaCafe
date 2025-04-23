using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _DefaultSocialComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultSocialComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Socials.ToList();
            return View(value);

        }
    }
}
