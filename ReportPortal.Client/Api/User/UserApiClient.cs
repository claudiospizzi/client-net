using System;
using System.Net.Http;
using System.Threading.Tasks;
using ReportPortal.Client.Api.User.Model;
using ReportPortal.Client.Converter;
using ReportPortal.Client.Extention;

namespace ReportPortal.Client.Api.User
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {
        public UserApiClient(HttpClient httpClient, string project) : base(httpClient, project)
        {
        }

        public async Task<UserModel> GetUserAsync()
        {
            var uri = HttpClient.BaseAddress.Append("/user");
            var response = await HttpClient.GetAsync(uri).ConfigureAwait(false);
            response.VerifySuccessStatusCode();
            return ModelSerializer.Deserialize<UserModel>(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
        }
    }
}
