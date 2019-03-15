﻿using System.Runtime.Serialization;

namespace ReportPortal.Client.Api.User.DataContract
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "full_name")]
        public string Fullname { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}