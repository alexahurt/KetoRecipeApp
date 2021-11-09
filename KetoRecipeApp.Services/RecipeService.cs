using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Recipes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new RecipeListItem
                                {
                                    Id = e.Id,
                                    Title = e.Title,
                                    Source = e.Source
                                }
                        );
                return query.ToArray();

            }
        }
    }
}
