using System.Collections.Generic;
using System.Threading.Tasks;
using RssContracts;

namespace RssDataModel.Repositories.Interfaces
{
    public interface INewsPostRepository : IRepository<NewsPost>
    {
        Task<IEnumerable<NewsPost>> GetNewsPost(int id);
    }
}
