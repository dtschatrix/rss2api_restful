using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using RssDataModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RssApi.Models.APIMethods;
using RssDataModel.Repositories;
using RssDataModel.Repositories.Classes;

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
            return _dmrsInstance ?? (_dmrsInstance = new DbMethodsRssService());
        }

        #endregion



        public async Task InsertNewsPostAsync(NewsPost news, RssContext rssContext)
        {
            using (var unitOfWork = new UnitOfWork(new RssContext()))
            {
                await unitOfWork.NewsPost.Add(news);
                await unitOfWork.Complete();
            }

            //await context.Add(news);
        }

        public async Task<string> GetDtoFromBaseAsync(string url)
        {
            using (var unitOfWork = new UnitOfWork(new RssContext()))
            {
                var result = unitOfWork.NewsPost.GetWithInclude(res => res.feed.Url == url,
                    rss => rss.items,
                    rss => rss.feed);
                await unitOfWork.NewsPost.Add(result);
                await unitOfWork.Complete();
                return await Task.Run(() => SerializeDto(result));
            }

        }

        public async Task<string> SerializeDto(object dto)
        {
            return JsonConvert.SerializeObject(dto, jss);
        }

        public Task CacheDictionary()
        {
            using (var unitOfWork = new UnitOfWork(new RssContext()) )
            {
                var query = unitOfWork.FeedList.Get(rss => rss.Url).Distinct();
                foreach (var item in query)
                {
                    RequestModelHandler.UrlDateDictionary.Add(new Uri(item), DateTime.Now);
                }
                return Task.CompletedTask;
            }
           
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