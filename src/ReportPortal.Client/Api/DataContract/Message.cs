using System.Runtime.Serialization;

namespace ReportPortal.Client.Api.DataContract
{
    [DataContract]
    public class Message
    {
        [DataMember(Name = "msg")]
        public string Info { get; set; }
    }
}
