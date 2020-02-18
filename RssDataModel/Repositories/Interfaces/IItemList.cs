using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RssDataModel;

namespace RssDataModel.Repositories.Interfaces
{
    public interface IItemList : IRepository<ItemList>
    {
        Task<IEnumerable<ItemList>> GetNewsItems(int id);

    }
}
