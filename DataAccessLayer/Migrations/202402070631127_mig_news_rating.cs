namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_news_rating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "NewsRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "NewsRating");
        }
    }
}
