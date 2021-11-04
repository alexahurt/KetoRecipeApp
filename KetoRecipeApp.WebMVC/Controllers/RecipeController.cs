﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KetoRecipeApp.Models;

namespace KetoRecipeApp.WebMVC.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            var model = new RecipeListItem[0];
            return View(model);
        }
    }
}