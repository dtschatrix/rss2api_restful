

using System;
using System.Data.Entity;
using System.Net.Http;
using System.Threading.Tasks;
using RssData.APIMethods;
using RssDataModel;

namespace RssData
{
   public class RssData
   {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new NullDatabaseInitializer<RssContext>());
            //RssMethods.InsertNewsPost();
            /*HttpClient client = new HttpClient();
            string resource = @"http://feeds.twit.tv/brickhouse.xml";
            Console.WriteLine(
            Rss2JsonAPI.GetApiResult(client, resource).GetAwaiter().GetResult());
            */
        }
    }
}
