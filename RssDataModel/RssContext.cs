using System.Data.Entity;
using RssContracts;

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
        public virtual DbSet<Feed>FeedLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<RssContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
