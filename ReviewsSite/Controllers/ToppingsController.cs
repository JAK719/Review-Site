using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ReviewsSite.Models;
using ReviewsSite.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ReviewsSite.Controllers
{
    public class ToppingsController : Controller
    {
        IRepository<Toppings> toppingsRepo;

        public ToppingsController(IRepository<Toppings> toppingsRepo)
        {
            this.toppingsRepo = toppingsRepo;
        }
        public ViewResult Index()
        {
            var toppingsList = toppingsRepo.GetAll();

            return View(toppingsList);
        }

        public ViewResult Details(int id)
        {
            var toppings = toppingsRepo.GetById(id);

            return View(toppings);
        }

        public ViewResult Update(int id)
        {
            var toppings = toppingsRepo.GetById(id);

            return View(toppings);
        }

        [HttpPost]
        public ViewResult Update(Toppings model)
        {
            toppingsRepo.Update(model);

            ViewBag.Result = "You have successfully updated this topping";

            return View(model);
        }
    }
}
