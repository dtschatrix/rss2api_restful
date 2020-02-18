using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssDataModel;

namespace RssDataModel.Repositories.Interfaces
{
    public interface INewsPost
    {
        Task<IEnumerable<NewsPost>> GetNewsPost(int id);
    }
}
