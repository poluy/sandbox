using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCF.Playing.Contracts
{
    [DataContract]
    public class GetPlayListResponse
    {
        [DataMember]
        public List<Track> Traks { get; set; }
    }
}
