using AcunMedyaCafe.Context;
using AcunMedyaCafe.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AcunMedyaCafe.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly CafeContext db;
        public DashboardController(CafeContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            ViewBag.UrunSayisi = db.Products.Count();
            ViewBag.AboneSayisi = db.Subscribers.Count();
            ViewBag.ReferansSayisi = db.Testimonials.Count();
            var subscribers = db.Subscribers.OrderByDescending(x=>x.SubscriberId).Take(15).ToList();
            return View(subscribers);
        }
    }
}