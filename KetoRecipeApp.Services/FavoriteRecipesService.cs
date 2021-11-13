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
                ctx.FavoriteRecipes.Add(entity);  //why the favoriterecips issue and .add not activating?
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
                    .Include(s => s.Podcast)  //include method not activating
                    .Where(e => e.UserId == _userId)
                    .Select(e =>
                    new FavoriteRecipesListItem
                    {
                        Id = e.Id,
                        UserId = e.UserId,
                        RecipeId = e.RecipeId,
                        Title = e.Podcast.Title,
                    });
                return query.ToArray(); //toarray not activating
            }
        }

        public FavoriteRecipesDetail GetFavoriteRecipesById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var favoriterecipes =
                    ctx
                    .FavoriteRecipes //favoriterecipes issue
                    .Include(s => s.Recipe)
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
                    .SingleOrDefault(e => e.Id == model.Id && e.UserId == _userId);

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
