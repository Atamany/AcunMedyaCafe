using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _AdminLayoutNotificationComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _AdminLayoutNotificationComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var notifications = _context.Subscribers.OrderByDescending(x => x.SubscriberId).Take(3).ToList();
            return View(notifications);

        }
    }
}
