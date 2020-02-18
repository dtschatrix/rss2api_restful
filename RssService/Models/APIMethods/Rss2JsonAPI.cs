using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RssApi.Models.APIMethods;
using RssDataModel;

namespace RssService
{
    public class Rss2JsonAPI
    {
        #region Private Fields

        private readonly string Api = @"https://api.rss2json.com/v1/api.json?rss_url=";
        private readonly string ApiKey = @"&n88tzqqjieiebw9djqqzmmnon9i6zwpljp3yorzc";

        private RssContext _dbContext;
        private DbMethodsRssService _dmrs;

        #endregion

        public Rss2JsonAPI()
        {
            _dmrs = DbMethodsRssService.GetInstance();
            _dbContext = new RssContext();
        }

        public async Task<string> GetApiResponseAsync(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetResponse(string url)
        {
            try
            {
                if (RequestModelHandler.UrlDateDictionary.ContainsKey(new Uri(url)))
                {
                    if (!RequestModelHandler.AddUriElement(new Uri(url), DateTime.Now, RequestModelHandler.UrlDateDictionary))
                        return await _dmrs.GetDtoFromBaseAsync(url);
                }
                else
                {
                    HttpSpecial http = new HttpSpecial();
                    var client = http.SpecialClient(url);
                    var response = await GetApiResponseAsync(client); //get response httpcontent as string
                    await Task.Run(()=> _dmrs.ApiResponseToDtoAsync(response)); // add result to base
                    response = await Task.Run(() => _dmrs.GetDtoFromBaseAsync(url)); //this is bad practice
                    return response;

                }
            }
            catch (Exception ex)
            {
                return "Something went wrong " + ex;
            }

            return "something happend";
        }
    }
}
