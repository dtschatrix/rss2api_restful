using System.Collections.Generic;
using System.Data.Entity;
using RssDataModel;
namespace RssDataModel
{
    public class RssContext:DbContext
    {
        public RssContext() : base("name=RssContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<NewsPost> NewsPosts { get; set; }
        public virtual DbSet<ItemList> ItemLists { get; set; }
        public virtual DbSet<FeedList>FeedLists { get; set; }

        public void DbContext()
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<RssContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
