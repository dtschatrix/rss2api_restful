namespace RssDataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feeds",
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
                        Message = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.NewsId);
            
            CreateTable(
                "dbo.ItemLists",
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
            DropForeignKey("dbo.Feeds", "Id", "dbo.NewsPosts");
            DropForeignKey("dbo.ItemLists", "NewsPost_NewsId", "dbo.NewsPosts");
            DropIndex("dbo.ItemLists", new[] { "NewsPost_NewsId" });
            DropIndex("dbo.Feeds", new[] { "Id" });
            DropTable("dbo.ItemLists");
            DropTable("dbo.NewsPosts");
            DropTable("dbo.Feeds");
        }
    }
}
