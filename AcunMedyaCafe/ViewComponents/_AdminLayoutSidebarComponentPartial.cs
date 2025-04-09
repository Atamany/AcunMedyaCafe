using AcunMedyaCafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedyaCafe.ViewComponents
{
    public class _AdminLayoutSidebarComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _AdminLayoutSidebarComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            if (Request.Cookies["AdminId"] != null)
            {
                string id = Request.Cookies["AdminId"];
                var adminId = int.Parse(id);
                var AccountName = _context.Admins
                    .Where(x => x.AdminId == adminId)
                    .Select(x => x.Username)
                    .FirstOrDefault();
                var AccountImage = _context.Admins
                    .Where(x => x.AdminId == adminId)
                    .Select(x => x.ProfilePhoto)
                    .FirstOrDefault();
                ViewBag.AccountName = AccountName;
                ViewBag.AccountImage = AccountImage;
            }
            else
            {
                ViewBag.AccountImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSrBQBC8A_xwJz4xJPVizRRea9xZLrjF2zB2Q&s";
                ViewBag.AccountName = "Misafir";
            }
            return View();

        }
    }
}
