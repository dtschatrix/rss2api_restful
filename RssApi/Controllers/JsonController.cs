using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Razor.Parser;
using RssData;
using RssData.APIMethods;

namespace RssApi.Controllers
{

    public class JsonController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get(int id, [FromUri] string url)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5

        [HttpGet]
        public string Get(int d)
        {
            return "value " + $"{d}";
        }

        // POST api/<controller>

        [HttpPost]
        public string Post([FromUri]string value)
        {

            return value;
        }

        // PUT api/<controller>/5
        //[HttpPut]
        /*public void Put(int id, [FromUri]string value)
        {
            
        }*/

        //[HttpPut]
        //public void Put(string url)
        //{
        //    
        //}

        [HttpPut]
        public async Task<IHttpActionResult> Put(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(url);
                    await Rss2JsonAPI.GetApiResult(client);
                    await Rss2JsonAPI.ApiResponseToDTO(Rss2JsonAPI.StaticResponse);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return NotFound();
        }

    }
}