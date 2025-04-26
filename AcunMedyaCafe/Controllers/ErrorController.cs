using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/Error404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
