namespace KetoRecipeApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationFixRecipeIdTypo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipe", "NutritionProfile_Id", "dbo.NutritionProfile");
            DropIndex("dbo.Recipe", new[] { "NutritionProfile_Id" });
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Rating = c.Double(nullable: false),
                        Text = c.String(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.FavoriteRecipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        RecipeId = c.Int(nullable: false),
                        RecipeTitle = c.String(),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            AddColumn("dbo.Recipe", "UserId", c => c.Guid(nullable: false));
            DropColumn("dbo.Recipe", "NutritionProfile_Id");
            DropTable("dbo.NutritionProfile");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NutritionProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fat = c.Double(nullable: false),
                        Protein = c.Double(nullable: false),
                        TotalCarbs = c.Double(nullable: false),
                        NetCarbs = c.Double(nullable: false),
                        Calories = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recipe", "NutritionProfile_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.FavoriteRecipes", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Comment", "RecipeId", "dbo.Recipe");
            DropIndex("dbo.FavoriteRecipes", new[] { "RecipeId" });
            DropIndex("dbo.Comment", new[] { "RecipeId" });
            DropColumn("dbo.Recipe", "UserId");
            DropTable("dbo.FavoriteRecipes");
            DropTable("dbo.Comment");
            CreateIndex("dbo.Recipe", "NutritionProfile_Id");
            AddForeignKey("dbo.Recipe", "NutritionProfile_Id", "dbo.NutritionProfile", "Id", cascadeDelete: true);
        }
    }
}
