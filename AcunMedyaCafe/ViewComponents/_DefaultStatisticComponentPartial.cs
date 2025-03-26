using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultStatisticComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.ProductCount = _context.Products.Count();
            ViewBag.CategoryCount = _context.Categories.Count();
            ViewBag.TestimonialCount = _context.Testimonials.Count();
            ViewBag.SubscriberCount = _context.Subscribers.Count();
            return View();

        }
    }
}
