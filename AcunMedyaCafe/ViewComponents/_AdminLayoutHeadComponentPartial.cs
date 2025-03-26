using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _AdminLayoutHeadComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
