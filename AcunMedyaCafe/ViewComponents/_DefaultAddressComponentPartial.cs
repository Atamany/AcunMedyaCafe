using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _DefaultAddressComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultAddressComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var address = _context.Adresses.FirstOrDefault();
            return View(address);

        }
    }
}
