using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.ViewModels;

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<CheeseCategory> categories = context.Categories.ToList();

            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();

            return View(addCategoryViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                CheeseCategory newCategory = new CheeseCategory();


                newCategory.Name = addCategoryViewModel.Name;

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }
            return View(addCategoryViewModel);


        }
    }
}

