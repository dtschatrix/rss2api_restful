using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RssService.Models.API
{
    public class HttpSpecialFactory
    {
        private readonly string Api = @"https://api.rss2json.com/v1/api.json?rss_url=";
        private readonly string ApiKey = @"&n88tzqqjieiebw9djqqzmmnon9i6zwpljp3yorzc";

        public HttpClient CreateWithUrl(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(Api + url + ApiKey);
            return client;
        }
    }
}