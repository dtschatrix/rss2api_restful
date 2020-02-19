using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssDataModel.Repositories.Interfaces;
using RssDataModel;

namespace RssDataModel.Repositories
{
    public class NewsPostRepo : Repository<NewsPost>, INewsPost
    {
        public RssContext RssContext => Context as RssContext;
        public NewsPostRepo(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<NewsPost>> GetNewsPost(int id)
        {
            //context.GetWithInclude
            //(res => res.feed.Url == url,
            //    rss => rss.items,
            //    rss => rss.feed);

            return await RssContext.NewsPosts.Include(news => news.NewsId == id).ToListAsync();
        }
    }
}
