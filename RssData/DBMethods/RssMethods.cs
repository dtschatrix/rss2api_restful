using System;
using RssDataModel;
using RssModel;

namespace RssData
{
    public class RssMethods
    {
        public static void InsertNewsPost(NewsPost news)
        {
            using (var context = new RssContext())
            {
                context.Database.Log = (s) => { Console.WriteLine(s); };
                context.NewsPosts.Add(news);
                context.SaveChanges();
            }
        }

        public static void DeleteNewsPost(NewsPost news)
        {
            using (var context = new RssContext())
            {
                context.Database.Log = (s) => { Console.WriteLine(s); };
                context.NewsPosts.Remove(news);
                context.SaveChanges();
            }

        }


    }
}
