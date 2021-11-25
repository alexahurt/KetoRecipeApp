using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    UserId = _userId,
                    Title = model.Title,
                    Instructions = model.Instructions,
                    Ingredients = model.Ingredients,
                    Category = model.Category,
                    MealType = model.MealType,
                    Protein = model.Protein,
                    TotalCarbs = model.TotalCarbs,
                    NetCarbs = model.NetCarbs,
                    Calories = model.Calories,
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
                var query = context.Recipes.Select(recipe => new RecipeListItem() 
                {
                    RecipeId = recipe.Id,
                    Title = recipe.Title,
                    Source = recipe.Source,
                });
                    
                return query.ToArray(); 
            }
        }

        public RecipeDetail GetRecipeById(int id)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var recipe = context.Recipes.Find(id);  

                if (recipe == null)
                {
                    return null;
                }

                return new RecipeDetail
                {
                    RecipeId = recipe.Id,
                    RecipeTitle = recipe.Title,
                    Category = recipe.Category,
                    MealType = recipe.MealType,
                    Instructions = recipe.Instructions,
                    Ingredients = recipe.Ingredients,
                    Source = recipe.Source,
                    IsCleanKeto = recipe.IsCleanKeto,
                    Comments = recipe.Comments.Select(comment => new CommentListItem()
                    {
                        CommentId = comment.CommentId,
                        Rating = comment.Rating,
                        Text = comment.Text
                    })
                };           
            }
        }

        public bool UpdateRecipe(RecipeEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                
                
                var entity = ctx.Recipes.SingleOrDefault(e => e.Id == model.Id && e.UserId == _userId);

                entity.Id = model.RecipeId;
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
