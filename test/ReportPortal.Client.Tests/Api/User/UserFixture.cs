﻿using ReportPortal.Client.Api.User.DataContract;
using System.Threading.Tasks;
using Xunit;

namespace ReportPortal.Client.Tests.Api.User
{
    public class UserFixture : BaseFixture
    {
        [Fact]
        public async Task GetUserInfo()
        {
            var user = await Service.User.GetUserAsync();
            Assert.Equal("Used for Net integration check via CI", user.Fullname);
            Assert.NotEmpty(user.Email);

            Assert.NotNull(user.AssignedProjects);
            Assert.NotEmpty(user.AssignedProjects.Keys);

            Assert.Contains("ci-agents-checks", user.AssignedProjects.Keys);
            Assert.Equal(ProjectRole.Member, user.AssignedProjects["ci-agents-checks"].ProjectRole);

        }
    }
}
