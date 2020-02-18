using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using RssService;

namespace RssApi
{
    public static class CacheConfig
    {
        //TODO: Run method on service to create cache.
        //public static void CacheDictionary()
        //{
        //    using (var context = new Repository<>())
        //    {
        //        var query = context.FeedLists.Select(feed => feed.Url).Distinct();
        //        foreach (var item in query)
        //        {
        //            RequestModelHandler.UrlDateDictionary.Add(new Uri(item),DateTime.Now);
        //        }
        //    }
            

        //    return Dictionary<Uri, DateTime > = null;
        //}

        public static void CacheDictionary()
        {
           DbMethodsRssService dmrs = new DbMethodsRssService();
           dmrs.CacheDictionary();
        }
    }
}