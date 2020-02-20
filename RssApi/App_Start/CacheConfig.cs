using System.Threading.Tasks;
using RssService;

namespace RssApi
{
    public static class CacheConfig
    {
        public static void CacheDictionary()
        {
            DbMethodsRssService dmrs = new DbMethodsRssService();
            Task.Run(() => dmrs.CacheDictionary());
        }
    }
}