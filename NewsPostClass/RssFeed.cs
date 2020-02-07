using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Http;

namespace RssModel
{
    //the DTO
    public class NewsPost
    {
        public int Id { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public FeedList feed { get; set; }
        public List<Itemlist> Itemlists { get; set; }


    }

    public class Itemlist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PubDate { get; set; }
        public string Link { get; set; }
        public string Guid { get; set; }
        public string Author { get; set; }
        public string Thumbnail { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string[] Categories { get; set; }
    }

    public class FeedList
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public int NewsPostId { get; set; }
        [Required]
        public NewsPost NewsPost { get; set; }
    }
}
