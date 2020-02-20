using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using RssContracts;
using RssDataModel.Repositories.Interfaces;

namespace RssDataModel.Repositories
{
    public class NewsPostRepository : Repository<NewsPost>, INewsPostRepository
    {
        public RssContext RssContext => Context as RssContext;
        public NewsPostRepository(DbContext context) : base(context) { }
        public async Task<IEnumerable<NewsPost>> GetNewsPost(int id)
        {
            return await RssContext.NewsPosts.Include(news => news.NewsId == id).ToListAsync();
        }
    }
}
