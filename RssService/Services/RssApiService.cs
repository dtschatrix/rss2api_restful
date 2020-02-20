using System;
using System.Net.Http;
using System.Threading.Tasks;
using RssContracts;
using RssService.Models.API;

namespace RssService
{
    public class RssApiService
    {
        private DbMethodsRssService _dmrs;
        public RssApiService()
        {
            _dmrs = DbMethodsRssService.GetInstance();
        }

        public async Task<string> GetApiResponseAsync(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<NewsPost> GetResponse(string url)
        {
            try
            {
                var rmh = RequestModelHandler.GetInstance();
                if (rmh.UrlDateDictionary.ContainsKey(new Uri(url)))
                {
                    if (!rmh.AddUriElement(new Uri(url), rmh.UrlDateDictionary))
                        return await _dmrs.GetDtoFromBaseAsync(url);
                }
                else
                {
                    rmh.AddUriElement(new Uri(url), rmh.UrlDateDictionary);
                    HttpSpecialFactory http = new HttpSpecialFactory();
                    var client = http.CreateWithUrl(url);
                    var response = await GetApiResponseAsync(client);
                    await Task.Run(() => _dmrs.ApiResponseToDtoAsync(response));
                    var result = await Task.Run(() => _dmrs.GetDtoFromBaseAsync(url)); 
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }
    }
}
