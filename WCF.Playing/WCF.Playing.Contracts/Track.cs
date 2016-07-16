using System;
using System.Runtime.Serialization;

namespace WCF.Playing.Contracts
{
    [DataContract]
    public class Track
    {
        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public TimeSpan Duration { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
