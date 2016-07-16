using System;
using System.Runtime.Serialization;

namespace WCF.Playing.Contracts
{
    [DataContract]
    public class GetPlayListRequest
    {
        [DataMember]
        public string FilterName { get; set; }

        [DataMember]
        public Guid ID { get; set; }
        
        [DataMember]
        public DateTime StartDate { get; set; }
    }
}
