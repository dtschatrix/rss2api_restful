using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using RssService;


namespace RssApi.Controllers
{

    public class JsonController : ApiController
    {
        //Get api/<controller>/?url= ...
        [HttpGet]
        public async Task<IHttpActionResult> Get(string url)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            Rss2JsonAPI rssService = new Rss2JsonAPI();
            var result = await rssService.GetResponse(url);
            HttpResponseMessage hrm = new HttpResponseMessage();
            hrm = Request.CreateResponse(HttpStatusCode.OK, 200);
            hrm.Content = new StringContent(result, Encoding.UTF8, "application/json");

            return ResponseMessage(hrm);


        }
    }


}

