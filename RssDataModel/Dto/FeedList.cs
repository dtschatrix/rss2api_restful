using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RssDataModel
{
    public class FeedList
    {
        [Key]
        [ForeignKey("NewsPost")]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual NewsPost NewsPost { get; set; }

    }
}