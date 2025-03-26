using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _AdminLayoutFooterComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _AdminLayoutFooterComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
