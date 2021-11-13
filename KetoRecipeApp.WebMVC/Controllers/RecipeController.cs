using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KetoRecipeApp.Models;
using KetoRecipeApp.Services;
using Microsoft.AspNet.Identity;

namespace KetoRecipeApp.WebMVC.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            var model = service.GetAllRecipes();

            return View(model);
        }
        //Add method here VVVV
        //GET

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreateRecipeService();
            
            if (service.CreateRecipe(model))
            {
                TempData["SaveResult"] = "Your recipe was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Recipe could not be created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateRecipeService();
            var model = svc.GetRecipeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRecipeService();
            var detail = service.GetRecipeById(id);
            var model =
                new RecipeEdit
                {
                    Id = detail.Id,
                    Title = detail.Title,
                    Category = detail.Category,
                    MealType = detail.MealType,
                    Instructions = detail.Instructions,
                    Ingredients = detail.Ingredients,
                    NutritionProfile = detail.NutritionProfile,
                    Source = detail.Source,
                    IsCleanKeto = detail.IsCleanKeto
                };

            return View(model);
        }

        private RecipeService CreateRecipeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            return service;
        }
    }
}