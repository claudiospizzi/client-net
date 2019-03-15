using System.Runtime.Serialization;

namespace ReportPortal.Client.Api.Launch.DataContract
{
    /// <summary>
    /// Describes modes for launches.
    /// </summary>
    public enum Mode
    {
        [DataMember(Name = "DEFAULT")]
        Default,
        [DataMember(Name = "DEBUG")]
        Debug
    }
}
