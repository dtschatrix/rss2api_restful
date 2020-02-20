using System.Threading.Tasks;
using RssDataModel.Repositories.Interfaces;

namespace RssDataModel.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly RssContext _rssContext;
        public INewsPostRepository NewsPostRepository { get; }
        public IFeedRepository FeedList { get; }
        public IItemListRepository ItemListRepository { get; }
        public UnitOfWork(RssContext rssContext)
        {
            _rssContext = rssContext;
            NewsPostRepository = new NewsPostRepository(rssContext);
            FeedList = new FeedRepository(rssContext);
            ItemListRepository = new ItemListRepository(rssContext);
        }
        public void Dispose()
        {
            _rssContext.Dispose();
        }
        public Task<int> Complete()
        {
            return _rssContext.SaveChangesAsync();
        }
    }
}
