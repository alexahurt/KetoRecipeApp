using System;
using System.Collections.Generic;
using System.Linq;
using KetoRecipeApp.Data;
using KetoRecipeApp.Models;

namespace KetoRecipeApp.Services
{
    public class RecipeService
    {
        private readonly Guid _userId;

        public RecipeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRecipe(RecipeCreate model)
        {
            var recipe =
                new Recipe()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Instructions = model.Instructions,
                    Ingredients = model.Ingredients,
                    Category = model.Category,
                    MealType = model.MealType,
                    Source = model.Source,
                    IsCleanKeto = model.IsCleanKeto
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Recipes.Add(recipe);    //recipes issue
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetAllRecipes()
        {
            using (var context = ApplicationDbContext.Create())
            {
                var query = context.Recipes.Select(recipe => new RecipeListItem() //Why is Recipes underlined + why isn't select method activating
                {
                    RecipeId = recipe.Id,
                    Title = recipe.Title,
                    Source = recipe.Source,
                });
                    
                return query.ToArray(); //Why isn't ToArray method activating?

            }
        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var recipe = context.Recipes.Find(id);  //Recipes issue

                if (recipe == null)
                {
                    return null;
                }

                return new RecipeDetail
                {
                    RecipeId = recipe.Id,
                    Title = recipe.Title,
                    Category = recipe.Category,
                    MealType = recipe.MealType,
                    Instructions = recipe.Instructions,
                    Ingredients = recipe.Ingredients,
                    //NutritionProfile = recipe.NutritionProfile,
                    Source = recipe.Source,
                    IsCleanKeto = recipe.IsCleanKeto
                };
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Recipes
                        .Single(e => e.Id == model.RecipeId && e.UserId == _userId);
                entity.Id = model.RecipeId;
                entity.Title = model.Title;
                entity.Category = model.Category;
                entity.MealType = model.MealType;
                entity.Instructions = model.Instructions;
                entity.Ingredients = model.Ingredients;
                entity.Protein = model.Protein;
                entity.TotalCarbs = model.TotalCarbs;
                entity.NetCarbs = model.NetCarbs;
                entity.Calories = model.Calories;
                entity.Source = model.Source;
                entity.IsCleanKeto = model.IsCleanKeto;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecipe(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var recipe = context.Recipes.Find(id);  //Recipes issue

                if (recipe == null)
                {
                    return false;
                }

                context.Recipes.Remove(recipe); //Recipes issue
                return context.SaveChanges() == 1;
            }
        }
    }
}
