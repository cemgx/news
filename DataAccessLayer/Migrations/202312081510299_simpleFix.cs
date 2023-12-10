namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class simpleFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "AuthorID", "dbo.Authors");
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Comments", "BlogID", "dbo.Blogs");
            DropIndex("dbo.Blogs", new[] { "CategoryID" });
            DropIndex("dbo.Blogs", new[] { "AuthorID" });
            DropIndex("dbo.Comments", new[] { "BlogID" });
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        NewsTitle = c.String(maxLength: 100),
                        NewsImage = c.String(maxLength: 100),
                        NewsDate = c.DateTime(nullable: false),
                        NewsContent = c.String(),
                        CategoryID = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewsID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.AuthorID);
            
            AddColumn("dbo.Comments", "NewsID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "NewsID");
            AddForeignKey("dbo.Comments", "NewsID", "dbo.News", "NewsID", cascadeDelete: true);
            DropColumn("dbo.Comments", "BlogID");
            DropTable("dbo.Blogs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        BlogTitle = c.String(maxLength: 100),
                        BlogImage = c.String(maxLength: 100),
                        BlogDate = c.DateTime(nullable: false),
                        BlogContent = c.String(),
                        CategoryID = c.Int(nullable: false),
                        AuthorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID);
            
            AddColumn("dbo.Comments", "BlogID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Comments", "NewsID", "dbo.News");
            DropForeignKey("dbo.News", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.News", "AuthorID", "dbo.Authors");
            DropIndex("dbo.Comments", new[] { "NewsID" });
            DropIndex("dbo.News", new[] { "AuthorID" });
            DropIndex("dbo.News", new[] { "CategoryID" });
            DropColumn("dbo.Comments", "NewsID");
            DropTable("dbo.News");
            CreateIndex("dbo.Comments", "BlogID");
            CreateIndex("dbo.Blogs", "AuthorID");
            CreateIndex("dbo.Blogs", "CategoryID");
            AddForeignKey("dbo.Comments", "BlogID", "dbo.Blogs", "BlogID", cascadeDelete: true);
            AddForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Blogs", "AuthorID", "dbo.Authors", "AuthorID", cascadeDelete: true);
        }
    }
}
