using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetoRecipeApp.Data;
using KetoRecipeApp.Models;

namespace KetoRecipeApp.Services
{
    public class FavoriteRecipesService
    {
        private readonly Guid _userId;

        public FavoriteRecipesService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFavoriteRecipes(FavoriteRecipesCreate model)
        {
            var entity =
                new FavoriteRecipes()
                {
                    UserId = _userId,
                    RecipeId = model.RecipeId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FavoriteRecipes.Add(entity);  
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FavoriteRecipesListItem> GetFavoriteRecipes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FavoriteRecipes  //favorite recipes issue
                    // .Include(e => e.Recipe)
                    .Where(e => e.UserId == _userId)
                    .Select(e =>
                    new FavoriteRecipesListItem
                    {
                        FavoriteRecipesId = e.Id,
                        UserId = e.UserId,
                        RecipeId = e.RecipeId,
                    });
                return query.ToArray(); 
            }
        }

        public FavoriteRecipesDetail GetFavoriteRecipesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var favoriterecipes =
                    ctx
                    .FavoriteRecipes 
                   // .Include(s => s.Recipe)
                    .SingleOrDefault(e => e.Id == id && e.UserId == _userId);

                if (favoriterecipes == null)
                {
                    return null;
                }

                return

                    new FavoriteRecipesDetail
                    {
                        UserId = favoriterecipes.UserId,
                        RecipeId = favoriterecipes.RecipeId,
                        RecipeTitle = favoriterecipes.RecipeTitle,
                        Source = favoriterecipes.Source
                    };

            }
        }

        public bool UpdateFavoriteRecipes(FavoriteRecipesEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FavoriteRecipes
                    .SingleOrDefault(e => e.Id == model.FavoriteRecipesId && e.UserId == _userId);

                if (entity == null)
                {
                    return false;
                }

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFavoriteRecipes(int recipeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FavoriteRecipes
                    .SingleOrDefault(e => e.Id == recipeId && e.UserId == _userId);

                if (entity == null)
                {
                    return false;
                }

                ctx.FavoriteRecipes.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
