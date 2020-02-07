using System.Data.Entity;
using RssModel;
namespace RssDataModel
{
    public class RssContext:DbContext
    {
        public DbSet<NewsPost> NewsPosts { get; set; }
        public DbSet<Itemlist> Itemlists { get; set; }
        public DbSet<FeedList> FeedLists { get; set; }

        public void DbContext()
        {

        }
    }
}
