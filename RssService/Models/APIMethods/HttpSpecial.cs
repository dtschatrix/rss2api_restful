using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RssApi.Models.APIMethods
{
    public class HttpSpecial
    {
        #region Private fields 

        private readonly string Api = @"https://api.rss2json.com/v1/api.json?rss_url=";
        private readonly string ApiKey = @"&n88tzqqjieiebw9djqqzmmnon9i6zwpljp3yorzc";

        #endregion

        

        public HttpClient SpecialClient(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(Api + url + ApiKey);
            return client;
        }

       





    }
}