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
        // GET: Recipe
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);
            var model = service.GetRecipes();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipeService(userId);

            service.CreateRecipe(model);

            return RedirectToAction("Index");
        }
    }
}