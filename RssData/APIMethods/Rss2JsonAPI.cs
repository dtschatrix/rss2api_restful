using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RssModel;

namespace RssData.APIMethods
{
    public static class Rss2JsonAPI
    {
        #region Private Static Fields
        private static readonly string Api = @"https://api.rss2json.com/v1/api.json?rss_url=";
        private static readonly string ApiKey = @"&n88tzqqjieiebw9djqqzmmnon9i6zwpljp3yorzc";
        #endregion

        #region Public Static
        public static HttpResponseMessage StaticResponse { get; set; }

        #endregion
        public static async Task<HttpResponseMessage> GetApiResult(HttpClient client)
        {
            string apiAddress = Api + client.BaseAddress + ApiKey;
            HttpResponseMessage response = await client.GetAsync(apiAddress);
            StaticResponse = response;
            return response;

        }

        public static async Task<string> ApiResponseToDTO(HttpResponseMessage response)
        {
            try
            {
                string json = await response.Content.ReadAsStringAsync();

                NewsPost news = JsonConvert.DeserializeObject<NewsPost>(json);

                await DbAdd(news);

                return "string";

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            
        }

        private static async Task<TaskStatus> DbAdd(NewsPost news)
        {
            try
            {
                RssMethods.InsertNewsPost(news);
                return TaskStatus.RanToCompletion;
            }
            catch (Exception)
            {
                return TaskStatus.Faulted;
            }
        }

        public static async Task DbContextStatus()
        {

        }

    }
}
