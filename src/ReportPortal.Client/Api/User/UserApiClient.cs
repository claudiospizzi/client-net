using System;
using System.Net.Http;
using System.Threading.Tasks;
using ReportPortal.Client.Api.User.DataContract;
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

            return await GetAsync<UserModel>(uri).ConfigureAwait(false);
        }
    }
}
