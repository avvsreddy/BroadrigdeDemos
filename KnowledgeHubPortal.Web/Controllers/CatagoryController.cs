using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHubPortal.Web.Controllers
{
    public class CatagoryController : Controller
    {
        //CatagoryRepository catagoryRepository = new CatagoryRepository();
        private ICatagoryRepository _repository;


        public CatagoryController(ICatagoryRepository repository)
        {
            this._repository = repository;
        }

        // .../catagory/index
        public IActionResult Index()
        {
            // Fetch the data from model

            //CatagoryRepository catagoryRepository = new CatagoryRepository();

            var catagories = _repository.GetAll();

            //List<Catagory> catagories = new List<Catagory>()
            //{
            //    new Catagory{Id=111, Name = "Sports", Description="Sports related articles" },
            //    new Catagory{Id=222, Name = "Education", Description="Education related articles" },
            //    new Catagory{Id=333, Name = ".Net", Description=".Net related articles" },
            //    new Catagory{Id=444, Name = "MVC", Description="MVC related articles" },
            //    new Catagory{Id=555, Name = "AI", Description="AI related articles" }
            //};

            // pass the data to view

            return View(catagories);
        }
        // .../catagory/create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Save(Catagory catagory)
        {
            // collect the data from ui
            // validate
            // pass to backend
            _repository.Save(catagory);
            // return a view
            return RedirectToAction("Index");
        }
    }
}
