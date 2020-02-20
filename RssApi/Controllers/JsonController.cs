using System.Threading.Tasks;
using System.Web.Http;
using RssContracts;
using RssService;

namespace RssApi.Controllers
{
    public class JsonController : ApiController
    {
        //Get api/<controller>/?url= ...
        [HttpGet]
        public async Task<NewsPost> Get(string url)
        {
            RssApiService rssService = new RssApiService();
            var result = await rssService.GetResponse(url);
            return result;
        }
    }
}

