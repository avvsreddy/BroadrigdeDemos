using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

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
        public IActionResult Index(int? page)
        {
            // Fetch the data from model

            //CatagoryRepository catagoryRepository = new CatagoryRepository();

            //var catagories = _repository.GetAll();

            //List<Catagory> catagories = new List<Catagory>()
            //{
            //    new Catagory{Id=111, Name = "Sports", Description="Sports related articles" },
            //    new Catagory{Id=222, Name = "Education", Description="Education related articles" },
            //    new Catagory{Id=333, Name = ".Net", Description=".Net related articles" },
            //    new Catagory{Id=444, Name = "MVC", Description="MVC related articles" },
            //    new Catagory{Id=555, Name = "AI", Description="AI related articles" }
            //};

            // pass the data to view

            int pageSize = 5;
            int pageNumber = page ?? 1;

            var categories = _repository.GetAll()
                .OrderBy(c => c.Name)
                .ToPagedList(pageNumber, pageSize);

            return View(categories);
        }
        // .../catagory/create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Catagory catagory)
        {
            // collect the data from ui
            // validate
            if (!ModelState.IsValid)
            {
                return View();
            }
            // pass to backend
            _repository.Save(catagory);
            // return a view
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);

            TempData["MSG"] = $"Category {id} successfully deleted";


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // fetch the all data based on id
            Catagory category = _repository.GetById(id);
            // return edit view
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _repository.Edit(catagory);
            TempData["MSG"] = $"Category {catagory.Id} successfully updated";
            return RedirectToAction("Index");
        }
    }
}
