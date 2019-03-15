using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ReportPortal.Client.Converter;

namespace ReportPortal.Client.Api.TestItem.DataContract
{
    [DataContract]
    public class TestItemHistoryModel
    {
        [DataMember(Name = "launchNumber")]
        public long LaunchNumber { get; set; }

        [DataMember(Name = "launchId")]
        public string LaunchId { get; set; }

        [DataMember(Name = "startTime")]
        public string StartTimeString { get; set; }

        public DateTime StartTime
        {
            get => DateTimeConverter.ConvertTo(StartTimeString);
        }

        [DataMember(Name = "launchStatus")]
        public string LaunchStatusString { get; set; }

        public Status LaunchStatus
        {
            get => EnumConverter.ConvertTo<Status>(LaunchStatusString);
        }

        [DataMember(Name = "resources")]
        public List<TestItemModel> Resources { get; set; }
    }
}
