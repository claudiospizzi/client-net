using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ReportPortal.Client.Api.DataContract
{
    [DataContract]
    public class PagingContent<T>
    {
        [DataMember(Name = "content")]
        public ICollection<T> Collection { get; set; }

        [DataMember(Name = "page")]
        public Page Page { get; set; }
    }
}
