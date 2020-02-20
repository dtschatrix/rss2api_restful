using System.Collections.Generic;
using System.Threading.Tasks;
using RssContracts;

namespace RssDataModel.Repositories.Interfaces
{
    public interface IItemListRepository : IRepository<ItemList>
    {
        Task<IEnumerable<ItemList>> GetNewsItems(int id);
    }
}
