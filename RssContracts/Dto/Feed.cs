using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RssContracts
{
    [DataContract]
    public class Feed
    {
        [ForeignKey("NewsPost"), Key, DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Url { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Image { get; set; }

        [DataMember]
        public virtual NewsPost NewsPost { get; set; }

    }
}