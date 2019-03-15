using System.Runtime.Serialization;

namespace ReportPortal.Client.Api.DataContract
{
    public enum QueryFilterOperation
    {
        [DataMember(Name = "eq")]
        Equals,
        [DataMember(Name = "ne")]
        NotEquals,
        [DataMember(Name = "cnt")]
        Contains,
        [DataMember(Name = "!cnt")]
        NotContains,
        [DataMember(Name = "ex")]
        Exists,
        [DataMember(Name = "in")]
        In,
        [DataMember(Name = "!in")]
        NotIn,
        [DataMember(Name = "gt")]
        GreaterThan,
        [DataMember(Name = "gte")]
        GreaterThanOrEquals,
        [DataMember(Name = "lt")]
        LowerThan,
        [DataMember(Name = "lte")]
        LowerThanOrEquals,
        [DataMember(Name = "btw")]
        Between,
        [DataMember(Name = "size")]
        Size,
        [DataMember(Name = "has")]
        Has
    }
}