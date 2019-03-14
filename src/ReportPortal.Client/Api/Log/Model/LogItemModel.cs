using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using ReportPortal.Client.Converter;

namespace ReportPortal.Client.Api.Log.Model
{
    [DataContract]
    public class LogItemModel
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "time")]
        public string TimeString { get; set; }

        public DateTime Time
        {
            get => DateTimeConverter.ConvertTo(TimeString);
        }

        [DataMember(Name = "message")]
        public string Text { get; set; }

        [DataMember(Name = "level")]
        public string LevelString { get; set; }

        public LogLevel Level
        {
            get => EnumConverter.ConvertTo<LogLevel>(LevelString);
        }

        [DataMember(Name = "binary_content")]
        public BinaryContent Content { get; set; }
    }

    [DataContract]
    public class BinaryContent
    {
        [DataMember(Name = "content_type")]
        public string ContentType { get; set; }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "thumbnail_id")]
        public string ThumbnailId { get; set; }
    }

    [DataContract]
    public class Attach
    {
        public Attach()
        {
        }

        public Attach(string name, string mimeType, byte[] data)
        {
            Name = name;
            MimeType = mimeType;
            Data = new ReadOnlyCollection<byte>(data);
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [IgnoreDataMember]
        public ReadOnlyCollection<byte> Data { get; }

        [IgnoreDataMember]
        public string MimeType { get; set; }
    }

    [DataContract]
    public class Responses
    {
        [DataMember(Name = "responses")]
        public List<LogItemModel> LogItems { get; set; }
    }
}
