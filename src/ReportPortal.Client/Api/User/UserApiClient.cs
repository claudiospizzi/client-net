using System;
using System.Net.Http;
using System.Threading.Tasks;
using ReportPortal.Client.Api.User.Model;
using ReportPortal.Client.Extension;

namespace ReportPortal.Client.Api.User
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {
        public UserApiClient(HttpClient httpClient, Uri baseUri, string project) : base(httpClient, baseUri, project)
        {
        }

        public async Task<UserModel> GetUserAsync()
        {
            var uri = BaseUri.Append("/user");

            return await SendAsync<UserModel, object>(HttpMethod.Get, uri, null).ConfigureAwait(false);
        }
    }
}
