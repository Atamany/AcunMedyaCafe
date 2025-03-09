using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
