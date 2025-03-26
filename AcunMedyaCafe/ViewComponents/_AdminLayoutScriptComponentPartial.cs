using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _AdminLayoutScriptComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _AdminLayoutScriptComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
