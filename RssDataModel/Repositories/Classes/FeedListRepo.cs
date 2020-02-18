using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RssDataModel.Repositories.Interfaces;
using RssDataModel;

namespace RssDataModel.Repositories
{
    public class FeedListRepo : Repository<FeedList>, IFeedlist
    {
        public RssContext RssContext => Context as RssContext;
        public FeedListRepo(DbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<FeedList>> GetFeedList(int id)
        {
           return await RssContext.FeedLists.Include(a => a.Id).ToListAsync();
        }

        
        
    }
}
