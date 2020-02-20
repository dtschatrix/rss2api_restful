using RssDataModel.Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace RssDataModel.Repositories
{
   public interface IUnitOfWork: IDisposable
    {
        INewsPostRepository NewsPostRepository { get; }
        IFeedRepository FeedList { get;  }
        IItemListRepository ItemListRepository { get; }

        Task<int> Complete();
    }
}
