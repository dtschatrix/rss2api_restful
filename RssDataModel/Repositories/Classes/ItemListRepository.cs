using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using RssContracts;
using RssDataModel.Repositories.Interfaces;

namespace RssDataModel.Repositories
{
    public class ItemListRepository : Repository<ItemList>, IItemListRepository
    {
        public RssContext RssContext => Context as RssContext;
        public ItemListRepository(DbContext context) : base(context) { }
        public async Task<IEnumerable<ItemList>> GetNewsItems(int newsPostId)
        {
            return await RssContext.ItemLists.Include(item => item.NewsPost.NewsId == newsPostId).ToListAsync();
        }
    }
}
