using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        // .../products/index
        public IActionResult Index()
        {

            // fetch the products from model
            // send the products to view

            return View();
        }
    }
}
