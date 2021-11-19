namespace KetoRecipeApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "CommentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comment", "CommentId");
        }
    }
}
