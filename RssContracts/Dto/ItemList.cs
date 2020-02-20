using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RssContracts
{
    [DataContract]
    public class ItemList
    {
        [Key, DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public DateTime? PubDate { get; set; }
        [DataMember]
        public string Link { get; set; }
        [DataMember]
        public string Guid { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Thumbnail { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string[] Categories { get; set; }
        [DataMember]
        public virtual NewsPost NewsPost { get; set; }
    }
}