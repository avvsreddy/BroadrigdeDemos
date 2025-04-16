using KnowledgeHubPortal.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.Web.Controllers
{
    public class CatagoryController : Controller
    {

        // .../catagory/index
        public IActionResult Index()
        {
            // Fetch the data from model

            List<Catagory> catagories = new List<Catagory>()
            {
                new Catagory{Id=111, Name = "Sports", Description="Sports related articles" },
                new Catagory{Id=222, Name = "Education", Description="Education related articles" },
                new Catagory{Id=333, Name = ".Net", Description=".Net related articles" },
                new Catagory{Id=444, Name = "MVC", Description="MVC related articles" },
                new Catagory{Id=555, Name = "AI", Description="AI related articles" }
            };

            // pass the data to view

            return View(catagories);
        }
    }
}
