using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KetoRecipeApp.Data;
using KetoRecipeApp.Models;
using KetoRecipeApp.Services;
using Microsoft.AspNet.Identity;

namespace KetoRecipeApp.WebMVC.Controllers
{
    public class FavoriteRecipesController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteRecipesService(userId);
            var model = service.GetFavoriteRecipes();

            return View(model);
        }
        //Add method here VVVV
        //GET

        public ActionResult Create()
        {
            var model = new FavoriteRecipesCreate();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FavoriteRecipesCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreateFavoriteRecipesService();

            if (service.CreateFavoriteRecipes(model))  //this method does exist in favoriterecipesservice
            {
                TempData["SaveResult"] = "Your recipe was added as a favorite.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Recipe could not be created.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateFavoriteRecipesService();
            var model = svc.GetFavoriteRecipesById(id);  //this method does exist in favorite recipes service page

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFavoriteRecipesService();
            var detail = service.GetFavoriteRecipesById(id);  //this method does exist
            var model =
                new FavoriteRecipes
                {
                    Id = detail.FavoriteRecipesId,
                    RecipeTitle = detail.RecipeTitle,
                    Source = detail.Source,
                    UserId = detail.UserId
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FavoriteRecipesEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FavoriteRecipesId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateFavoriteRecipesService();

            if (service.UpdateFavoriteRecipes(model))
            {
                TempData["SaveResult"] = "Your Recipe was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your recipe could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateFavoriteRecipesService();
            var model = svc.GetFavoriteRecipesById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRecipe(int id)
        {
            var service = CreateFavoriteRecipesService();
            service.DeleteFavoriteRecipes(id);
            TempData["SaveResult"] = "Your recipe was deleted";
            return RedirectToAction("Index");
        }

        private FavoriteRecipesService CreateFavoriteRecipesService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FavoriteRecipesService(userId);
            return service;
        }
    }
}