namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_newsRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "NewsRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "NewsRating");
        }
    }
}
