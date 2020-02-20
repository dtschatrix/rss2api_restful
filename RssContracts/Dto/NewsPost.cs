using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RssContracts
{
    [DataContract]
    public class NewsPost
    {
        [Key, DataMember]
        public int NewsId { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public Feed Feed { get; set; }
        [DataMember]
        public List<ItemList> Items { get; set; }
    }
}
