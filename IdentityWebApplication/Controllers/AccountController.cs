using Microsoft.AspNetCore.Mvc;

namespace IdentityWebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
