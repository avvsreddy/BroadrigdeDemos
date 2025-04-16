using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        //URL: .../home/index
        public IActionResult Index()
        {
            return View();
        }

        // .../home/privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // .../home/about
        public ViewResult About()
        {
            string msg = "This is about a sample mvc application";

            return View();
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
