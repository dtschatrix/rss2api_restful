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
    public class ItemListRepo : Repository<ItemList>, IItemList
    {
        public RssContext RssContext => Context as RssContext;

        public ItemListRepo(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ItemList>> GetNewsItems(int newsPostId)
        {
            return await RssContext.ItemLists.Include(item => item.NewsPost.NewsId == newsPostId).ToListAsync();
        }

    }

}
