using Microsoft.AspNetCore.Mvc;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using AcunMedyaCafe.Context;

namespace AcunMedyaCafe.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        CafeContext db = new CafeContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var account = db.Admins.FirstOrDefault(x => x.Username == username);
            if (account == null || account.Password != password)
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
            else
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
                SetCookie("AdminId", account.AdminId);
                var identity = new ClaimsIdentity(claims, "AdminId");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("AdminId", principal);

                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
            }
        }
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("AdminId");
            await HttpContext.SignOutAsync("AdminId");
            return RedirectToAction("Index", "Login");
        }

        private void SetCookie(string key, int value, int? expireTime = null)
        {
            var option = new CookieOptions
            {
                Expires = expireTime.HasValue ? DateTime.Now.AddMinutes(expireTime.Value) : DateTime.Now.AddDays(7),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };
            Response.Cookies.Append(key, value.ToString(), option);
        }
    }
}