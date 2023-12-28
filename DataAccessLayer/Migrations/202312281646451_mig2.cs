namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "CommentText", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentText", c => c.String(maxLength: 300));
            DropColumn("dbo.Comments", "CommentDate");
        }
    }
}
