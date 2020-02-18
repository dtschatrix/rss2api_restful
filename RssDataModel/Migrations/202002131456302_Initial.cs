namespace RssDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedLists",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Url = c.String(),
                        Title = c.String(),
                        Link = c.String(),
                        Author = c.String(),
                        Description = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsPosts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.NewsPosts",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        message = c.String(),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.NewsId);
            
            CreateTable(
                "dbo.Itemlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PubDate = c.DateTime(),
                        Link = c.String(),
                        Guid = c.String(),
                        Author = c.String(),
                        Thumbnail = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        NewsPost_NewsId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsPosts", t => t.NewsPost_NewsId)
                .Index(t => t.NewsPost_NewsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedLists", "Id", "dbo.NewsPosts");
            DropForeignKey("dbo.Itemlists", "NewsPost_NewsId", "dbo.NewsPosts");
            DropIndex("dbo.Itemlists", new[] { "NewsPost_NewsId" });
            DropIndex("dbo.FeedLists", new[] { "Id" });
            DropTable("dbo.Itemlists");
            DropTable("dbo.NewsPosts");
            DropTable("dbo.FeedLists");
        }
    }
}
