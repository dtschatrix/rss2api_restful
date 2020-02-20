using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using RssContracts;
using RssDataModel.Repositories.Interfaces;

namespace RssDataModel.Repositories
{
    public class FeedRepository : Repository<Feed>, IFeedRepository
    {
        public RssContext RssContext => Context as RssContext;
        public FeedRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Feed>> GetFeedList(int id)
        {
            return await RssContext.FeedLists.Include(a => a.Id).ToListAsync();
        }
    }
}
