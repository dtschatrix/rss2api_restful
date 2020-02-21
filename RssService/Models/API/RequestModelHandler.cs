using System;
using System.Collections.Generic;

namespace RssService.Models.API
{
    public class RequestModelHandler
    {
        public IDictionary<Uri, DateTime> UrlDateDictionary { get; set; }

        private static RequestModelHandler _requestModelHandler;

        internal RequestModelHandler()
        {
            UrlDateDictionary = new Dictionary<Uri, DateTime>();
        }

        public static RequestModelHandler GetInstance()
        {
            return _requestModelHandler ?? (_requestModelHandler = new RequestModelHandler());
        }
        public bool AddUriElement(Uri url, IDictionary<Uri, DateTime> dictionary)
        {
            var date = DateTime.Now;
            if (!dictionary.ContainsKey(url))
            {
                dictionary.Add(url, date);
                return true;
            }
            if (dictionary[url].AddHours(1) < DateTime.Now)
            {
                dictionary[url] = date;
                return true;
            }
            return false;
        }
    }
}
