using System;
using System.Collections.Generic;

namespace RssService
{
    public class RequestModelHandler
    {
        public static IDictionary<Uri, DateTime> UrlDateDictionary { get; set; }

        static RequestModelHandler()
        {
            UrlDateDictionary = new Dictionary<Uri, DateTime>();
        }
        //TODO: refactor this?
        public static bool AddUriElement(Uri url, DateTime date, IDictionary<Uri, DateTime> dictionary)
        {
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
