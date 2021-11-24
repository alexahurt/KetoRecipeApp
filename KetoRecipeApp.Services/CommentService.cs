using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetoRecipeApp.Data;
using KetoRecipeApp.Models;

namespace KetoRecipeApp.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var recipe = ctx.Recipes.Find(model.RecipeId);  //Recipes issue

                if (recipe == null)
                {
                    return false;
                }

                var comment =
                    new Comment()
                    {
                        //UserId = _userId,
                        Rating = model.Rating,
                        Text = model.Text,
                        RecipeId = model.RecipeId
                    };

                ctx.Comments.Add(comment);    //issues with Comments
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetCommentsByRecipeId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments    //comments issue
                        .Where(e => e.RecipeId == id)  //why isn't where method activating
                        .Select(                       //why isn't Select method activating
                            e =>
                                new CommentListItem
                                {
                                    CommentId = e.CommentId,
                                    Rating = e.Rating,
                                    Text = e.Text
                                }
                        );
                return query.ToArray();    //why isn't ToArray method activating
            }
        }

        public CommentListItem GetCommentsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comment =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id);
                var model = new CommentListItem
                {
                    CommentId = comment.CommentId,
                    Rating = comment.Rating,
                    Text = comment.Text
                };
          
                return model;    
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comment =
                    ctx
                        .Comments  //comments issue
                        .SingleOrDefault(e => e.Id == model.CommentId && e.UserId == _userId);  //SingleOrDefault not activating

                if (comment == null)
                {
                    return false;
                }
                
                comment.Rating = model.Rating;
                comment.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var comment =
                    ctx
                        .Comments //comments issue
                        .SingleOrDefault(e => e.Id == id && e.UserId == _userId); //SingleOrDefault not activating

                if (comment == null)
                {
                    return false;
                }

                ctx.Comments.Remove(comment); //comments issue

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
