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
            var entity =
                new Recipe()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Instructions = model.Instructions,
                    Ingredients = model.Ingredients,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RecipeListItem> GetRecipes()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = 
                    context
                    .Recipes
                    .Include(r => r.Recipe)
                    .Where(r => r.UserId == _userId)
                    .Select(r => new RecipeListItem
                    {
                        Id = r.Id,
                        UserId = r.UserId,
                        Title = r.Title,
                        Source = r.Source
                    });
                return query.ToArray();

            }
        }
    }
}
