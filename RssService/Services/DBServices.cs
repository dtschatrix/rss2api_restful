using System;
using System.Linq;
using System.Net.Http;
using RssDataModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RssContracts;
using RssDataModel.Repositories.Classes;
using RssService.Models.API;

namespace RssService
{
    public class DbMethodsRssService
    {
        public static JsonSerializerSettings jss =
             new JsonSerializerSettings
             { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        private static DbMethodsRssService _dmrsInstance;

        public static DbMethodsRssService GetInstance()
        {
            return _dmrsInstance ?? (_dmrsInstance = new DbMethodsRssService());
        }

        public async Task InsertNewsPostAsync(NewsPost news)
        {
            using (var unitOfWork = new UnitOfWork(new RssContext()))
            {
                await unitOfWork.NewsPostRepository.Add(news);
                await unitOfWork.Complete();
            }
        }
        public async Task<NewsPost> GetDtoFromBaseAsync(string url)
        {
            using (var unitOfWork = new UnitOfWork(new RssContext()))
            {
                var result = unitOfWork.NewsPostRepository.GetWithInclude(res => res.Feed.Url == url,
                    rss => rss.Items,
                    rss => rss.Feed);
                return result;
            }
        }
        public async Task CacheDictionary()
        {
            var rmh = RequestModelHandler.GetInstance();
            var ras = new RssApiService();
            var http = new HttpSpecialFactory();
            using (var unitOfWork = new UnitOfWork(new RssContext()))
            {
                HttpClient client;
                var query = unitOfWork.FeedList.Select(rss => rss.Url).Distinct();
                foreach (var item in query)
                {
                    rmh.UrlDateDictionary.Add(new Uri(item), DateTime.Now);
                    client = http.CreateWithUrl(item);
                    var response = await ras.GetApiResponseAsync(client);
                    await _dmrsInstance.ApiResponseToDtoAsync(response);
                }
            }
        }
        public async Task ApiResponseToDtoAsync(string response)
        {
            try
            {
                var news = JsonConvert.DeserializeObject<NewsPost>(response);
                await InsertNewsPostAsync(news);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}