using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Http;

namespace RssDataModel
{
    //the DTO
    public class NewsPost
    {
        [Key]
        public int NewsId { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public FeedList feed { get; set; }
        public List<ItemList> items { get; set; }


    }
}
