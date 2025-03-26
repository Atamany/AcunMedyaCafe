using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
