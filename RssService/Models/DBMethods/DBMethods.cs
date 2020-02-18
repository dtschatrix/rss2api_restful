using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using RssDataModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RssApi.Models.APIMethods;
using RssDataModel.Repositories;

namespace RssService
{
    public class DbMethodsRssService 
    {
        #region Public Static Property

        public static JsonSerializerSettings jss =
            new JsonSerializerSettings
            { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        #endregion

        #region Singleton
        private static DbMethodsRssService _dmrsInstance;

        public static DbMethodsRssService GetInstance()
        {
            if (_dmrsInstance == null)
            {
                _dmrsInstance = new DbMethodsRssService();
            }

            return _dmrsInstance;
        }

        #endregion



        public async Task InsertNewsPostAsync(NewsPost news, RssContext rssContext)
        {
            var context = new Repository<NewsPost>(rssContext);
            await context.Add(news);
        }

        public async Task<string> GetDtoFromBaseAsync(string url)
        {
            var context = new Repository<NewsPost>(new RssContext());
            {
                var result = context.GetWithInclude
                    (res => res.feed.Url == url, 
                    rss => rss.items,
                    rss => rss.feed);
                
                return await Task.Run(() => SerializeDto(result));
            }

        }

        public async Task<string> SerializeDto(object dto)
        {
            return JsonConvert.SerializeObject(dto, jss);
        }

        public Task CacheDictionary()
        {
            //this is hack
            RssContext rssContext = new RssContext();
            var context = new Repository<FeedList>(rssContext);
            var query = context.Get(rss=> rss.Url).Distinct();
            foreach (var item in query)
            {
                RequestModelHandler.UrlDateDictionary.Add(new Uri(item), DateTime.Now);
            }
            return Task.CompletedTask;
        }

        public async Task ApiResponseToDtoAsync(string response)
        {
            try
            {
                var news = JsonConvert.DeserializeObject<NewsPost>(response);
                await InsertNewsPostAsync(news, new RssContext());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
    }