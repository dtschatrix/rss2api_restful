using RssDataModel.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace RssDataModel.Repositories
{
   public interface IUnitOfWork: IDisposable
    {
        INewsPost NewsPost { get; }
        IFeedlist FeedList { get;  }
        IItemList ItemList { get; }

        Task<int> Complete();
    }
}
