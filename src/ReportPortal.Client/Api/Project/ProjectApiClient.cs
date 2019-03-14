using System;
using System.Net.Http;
using System.Threading.Tasks;
using ReportPortal.Client.Api.Project.Model;
using ReportPortal.Client.Api.Project.Request;
using ReportPortal.Client.Extension;

namespace ReportPortal.Client.Api.Project
{
    public class ProjectApiClient : BaseApiClient, IProjectApiClient
    {
        public ProjectApiClient(HttpClient httpClient, Uri baseUri, string project) : base(httpClient, baseUri, project)
        {
        }

        public async Task<UpdatePreferencesResponse> UpdatePreferencesAsync(UpdatePreferenceRequest model, string userName)
        {
            var uri = BaseUri.Append($"project/{Project}/preference/{userName}");

            return await SendAsync<UpdatePreferencesResponse, UpdatePreferenceRequest>(HttpMethod.Put, uri, model).ConfigureAwait(false);
        }

        public async Task<Preference> GetPreferencesAsync(string userName)
        {
            var uri = BaseUri.Append($"project/{Project}/preference/{userName}");

            return await SendAsync<Preference, object>(HttpMethod.Get, uri, null).ConfigureAwait(false);
        }
    }
}
