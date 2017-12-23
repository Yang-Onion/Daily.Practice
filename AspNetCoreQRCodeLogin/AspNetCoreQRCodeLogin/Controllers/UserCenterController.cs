using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreQRCodeLogin.Controllers
{
    [Authorize]
    public class UserCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Redict()
        {
            return RedirectToAction("Index", "UserCenter");
        }
    }
}
