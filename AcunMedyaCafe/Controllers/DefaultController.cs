using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Controllers
{
    public class DefaultController : Controller
    {
        private readonly CafeContext _context;

        public DefaultController(CafeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
