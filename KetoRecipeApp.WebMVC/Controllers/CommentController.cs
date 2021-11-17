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
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            return View(service);
        }
        //Add method here VVVV
        //GET

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate model)
        {
            if (ModelState.IsValid) return View(model);

            var service = CreateCommentService();

            if (service.CreateComment(model))
            {
                TempData["SaveResult"] = "Your comment was posted.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Comment could not be posted.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentsByRecipeId(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCommentService();
            var detail = service.GetCommentsByRecipeId(id);
            var model =
                new CommentEdit
                {
                    CommentId = detail.CommentId,
                    Rating = detail.Rating,
                    Text = detail.Text
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CommentId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCommentService();

            if (service.UpdateComment(model))
            {
                TempData["SaveResult"] = "Your comment was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your comment could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentsByRecipeId(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int id)
        {
            var service = CreateCommentService();
            service.DeleteComment(id);
            TempData["SaveResult"] = "Your comment was deleted";
            return RedirectToAction("Index");
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            return service;
        }
    }
}