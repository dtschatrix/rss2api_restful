using System.Collections.Generic;
using System.Threading.Tasks;
using RssContracts;

namespace RssDataModel.Repositories.Interfaces
{
    public interface IFeedRepository : IRepository<Feed>
    {
        Task<IEnumerable<Feed>> GetFeedList(int id);
    }
}
