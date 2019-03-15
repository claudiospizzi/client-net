using System;
using ReportPortal.Client.Api.DataContract;
using ReportPortal.Client.Converter;
using Xunit;

namespace ReportPortal.Client.Tests.Serialization
{
    public class ModelSerialization
    {
        [Fact]
        public void ShouldThrowExceptionIfIncorrectJson()
        {
            var json = "<abc />";
            var exp = Assert.ThrowsAny<Exception>(() => ModelSerializer.Deserialize<Message>(json));
            Assert.Contains(json, exp.Message);
            Assert.NotNull(exp.InnerException);
        }
    }
}
