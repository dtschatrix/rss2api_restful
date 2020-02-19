using System.Threading.Tasks;
using RssDataModel.Repositories.Interfaces;

namespace RssDataModel.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly RssContext _rssContext;
        public INewsPost NewsPost { get; }
        public IFeedlist FeedList { get; }
        public IItemList ItemList { get; }

        public UnitOfWork(RssContext rssContext)
        {
            _rssContext = rssContext;
            NewsPost = new NewsPostRepo(rssContext);
            FeedList = new FeedListRepo(rssContext);
            ItemList = new ItemListRepo(rssContext);
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
