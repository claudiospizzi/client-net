using ReportPortal.Client.Converter;
using System.Runtime.Serialization;

namespace ReportPortal.Client.Api.User.DataContract
{
    [DataContract]
    public class ProjectAssigment
    {
        [DataMember(Name = "projectRole")]
        public string ProjectRoleString { get; set; }

        public ProjectRole ProjectRole
        {
            get => EnumConverter.ConvertTo<ProjectRole>(ProjectRoleString);
            set => ProjectRoleString = EnumConverter.ConvertFrom(value);
        }
    }
}
